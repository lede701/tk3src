using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tk3full.Data;
using tk3full.DSOs;

namespace tk3full.Controllers
{
    public class AuthController : Tk3BaseController
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<DsoUser> Index()
        {
            return new DsoUser
            {
                userName = "lede",
                token = "aaaaa"
            };
        }
    }
}
