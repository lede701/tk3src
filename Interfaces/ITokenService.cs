using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.Entities;

namespace tk3full.Interfaces
{
    public interface ITokenService
    {
        String CreateToken(Tk3User user);
        Task<bool> RevokeToken(Tk3User user);
    }
}
