using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class InsertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Insert([FromBody] System.Text.Json.JsonElement data)
        {
            bool operation = false;
            string msg = "";
            string id = data.GetProperty("id").ToString();
            string name = data.GetProperty("name").ToString();
            string category = data.GetProperty("category").ToString();
            string sellPrice = data.GetProperty("sellPrice").ToString();
            string buyPrice = data.GetProperty("buyPrice").ToString();

            if (true)
            {
                operation = true;
                msg = "Produto cadastrado com sucesso";
            }
            else
            {
                //msg = "Dados inválidos";
            }

            return Json(new
            {
                operation = operation,
                msg = msg
            });
        }
    }
}
