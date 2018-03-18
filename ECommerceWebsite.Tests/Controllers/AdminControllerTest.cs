using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ECommerceWebsite.Controllers;

namespace ECommerceWebsite.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void AllUsers()
        {
            AdminController controller = new AdminController();
            ViewResult result = controller.AllUsers();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetUserOrders()
        {
            AdminController controller = new AdminController();
            ViewResult result = controller.GetUserOrders(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetOrderSummary()
        {
            AdminController controller = new AdminController();
            ViewResult result = controller.GetOrderSummary(1);
            Assert.IsNotNull(result);
        }
    }
}
