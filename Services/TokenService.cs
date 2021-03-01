using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using tk3full.Entities;
using tk3full.Interfaces;

namespace tk3full.Services
{
    public class TokenService : ITokenService
    {
		private readonly SymmetricSecurityKey _key;
		private Dictionary<String, TokenEntity> _validations = new Dictionary<String, TokenEntity>();
		private int _expiresInMinutes;

		public TokenService(IConfiguration config)
		{
			_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
			_expiresInMinutes = Convert.ToInt32(config["TokenAgeInMinutes"]);
		}

		public async Task<string> CreateTokenAsync(Tk3User user)
		{
			// Create token experation date
			DateTime expDate = DateTime.Now.AddMinutes(_expiresInMinutes);
			// Create new cliam
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.NameId, user.guId.ToString()),
				new Claim(JwtRegisteredClaimNames.Exp, expDate.ToString())
			};

			// Create new cedentials
			var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.Now.AddDays(7),
				SigningCredentials = creds
			};
			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);

			// Adding token to validations
			TokenEntity te = new TokenEntity
			{
				Token = tokenHandler.WriteToken(token),
				UserName = user.userName
			};

			await Task.Run(() =>
			{
				lock (_validations)
				{
					_validations[te.UserName] = te;
				}
			});


			return te.Token;
		}

		public async Task<bool> RevokeTokenAsync(Tk3User user)
        {
			bool bRetVal = false;
			await Task.Run(() =>
			{
			   if (_validations.ContainsKey(user.userName))
			   {
				   lock (_validations)
				   {
					   _validations.Remove(user.userName);
				   }
					bRetVal = true;
			   }
			});

			return bRetVal;
        }
	}
}
