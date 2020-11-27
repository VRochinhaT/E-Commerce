using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            if(Request.Cookies["CookieAuth"] != null)
            {
                return Redirect("/Home");
            }

            return View();
        }

        public IActionResult Logout()
        {
            Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync(HttpContext);

            return Redirect("/Home");
        }

        public IActionResult Login([FromBody] System.Text.Json.JsonElement data)
        {
            bool operation = false;
            string msg = "";
            string email = data.GetProperty("email").ToString();
            string password = data.GetProperty("password").ToString();

            Models.User user = new Models.User();

            if(user.AuthentifyPassword(email, password))
            {
                operation = true;
                msg = "Bem-vindo";

                #region Gerando Cookie de Autorização

                var userClaims = new List<Claim>();
                userClaims.Add(new Claim("id", email));
                //userClaims.Add(new Claim("name", user.Name));

                var identity = new ClaimsIdentity(userClaims, "Identificação do Usuario");

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                //Gerando cookie
                Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignInAsync(HttpContext, principal);


                #endregion
            }
            else
            {
                msg = "Dados inválidos";
            }

            return Json(new
            {
                operation = operation,
                msg = msg
            });
        }
    }
}
