using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalidadT2.Models;
using CalidadT2.Repositories;
using CalidadT2.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUsuarioRepo _usuarioRepo;
        private readonly IAuthService auth;


        public AuthController(IUsuarioRepo usuarioRepo, IAuthService auth)
        {
            this.auth = auth;
            this._usuarioRepo = usuarioRepo;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var usuario = _usuarioRepo.FindUserByCredentials(username,password);
            if (usuario != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                auth.Login(claims);
                
                return RedirectToAction("Index", "Home");
            }
            
            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            ModelState.AddModelError("LoginValidation", "Usuario o contraseña Incorercta");
            return View();
        }


        public ActionResult Logout()
        {
            auth.Logout();
            return RedirectToAction("Login");
        }
    }
}
