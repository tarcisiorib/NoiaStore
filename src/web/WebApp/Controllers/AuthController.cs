using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

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

            var result = await _authService.Register(registerUser);

            await LogIn(result);

            //if (false) return View(registerUser);

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

            var result = await _authService.Login(loginUser);

            await LogIn(result);

            //if (false) return View(loginUser);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet()]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        private async Task LogIn(User user)
        {
            var token = GetFormatedToken(user.AccessToken);

            var claims = new List<Claim>();
            claims.Add(new Claim ("JWT", user.AccessToken));
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                IsPersistent = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        private static JwtSecurityToken GetFormatedToken(string jwtToken)
            => new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
    }
}
