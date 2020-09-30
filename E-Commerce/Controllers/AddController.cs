using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class AddController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }
    }
}
