using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {

            return View();
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
