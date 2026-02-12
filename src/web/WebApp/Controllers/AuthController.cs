using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet()]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost()]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            if (!ModelState.IsValid) return View(registerUser);

            // api/register

            if (false) return View(registerUser);

            // api/login

            return RedirectToAction("Index", "Home");
        }

        [HttpGet()]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost()]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (!ModelState.IsValid) return View(loginUser);

            // api/login

            if (false) return View(loginUser);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet()]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
