using Microsoft.VisualStudio.TestTools.UnitTesting;
using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Models.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void InsertTest()
        {
            Models.User user = new User();
            user.Id = 0;
            user.Name = "Ro";
            user.Email = "vitor@rocha.com";
            user.Password = "123456";

            bool ok = user.Insert();

            Assert.IsTrue(ok);
        }

        [TestMethod()]
        public void AuthentifyPasswordTest()
        {
            Models.User user = new User();

            bool ok = user.AuthentifyPassword("vitor@rocha.com", "123456");

            Assert.IsTrue(ok);
        }

        [TestMethod()]
        public void SelectTest()
        {
            Models.User user = new User();
            bool ok = user.Select(1);

            Assert.IsTrue(ok);
        }

        [TestMethod()]
        public void SearchTest()
        {
            Models.User user = new User();

            var list = user.Search("%");

            Assert.IsTrue(list.Count > 0);
        }
    }
}