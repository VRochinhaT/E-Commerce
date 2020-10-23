using Microsoft.VisualStudio.TestTools.UnitTesting;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Models.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            Models.Product prod = new Product();
            prod.Name = "Parafuso";
            prod.Category = "Categoria1";
            prod.SellPrice = 10;
            prod.BuyPrice = 7;

            bool ok = prod.Insert();
            Assert.IsTrue(ok);
        }
    }
}