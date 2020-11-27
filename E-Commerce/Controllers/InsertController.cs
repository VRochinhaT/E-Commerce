using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Authorize("CookieAuth")]

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

        public IActionResult SearchProduct()
        {
            return View();
        }

       public IActionResult ExecuteSearch(string q)
        {
            Models.Product p = new Models.Product();
            List<Models.Product> datas = p.Search(q);


            return Json(datas);
        }

        public IActionResult Insert([FromBody] System.Text.Json.JsonElement data)
        {
            bool operation = false;
            string msg = "";
            //string id = data.GetProperty("id").ToString();
            
            /*string name = data.GetProperty("name").ToString();
            string category = data.GetProperty("category").ToString();
            string sellPrice = data.GetProperty("sellPrice").ToString();
            string buyPrice = data.GetProperty("buyPrice").ToString();*/

            Models.Product prod = new Models.Product();

            prod.Name = data.GetProperty("name").ToString();
            prod.Category = data.GetProperty("category").ToString();
            prod.SellPrice = Convert.ToDecimal(data.GetProperty("sellPrice").ToString());
            prod.BuyPrice = Convert.ToDecimal(data.GetProperty("buyPrice").ToString());

            if (prod.Insert())
            {
                operation = true;
                msg = "Produto cadastrado com sucesso";
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
