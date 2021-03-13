using System.Threading.Tasks;
using Core.Entities.TimeSheets;
using Core.Interfaces;
using System.Security.Claims;
using Core.Entities;
using System;

namespace API.Extensions
{
	public static class ClaimsPrincipleExtensions
	{
		public static string GetUsername(this ClaimsPrincipal user)
		{
			return user.FindFirst(ClaimTypes.Name)?.Value;
		}

		public static Guid GetUserId(this ClaimsPrincipal user)
		{
			return Guid.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
		}

		public static async Task<Tk3User> GetUserAsync(this ClaimsPrincipal user, IGenericRepository<Tk3User> userRepo)
		{
			Guid guid = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
			var who = await userRepo.GetByGuidAsync(guid);
			return who;
		}
	}
}
