using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ECommerceWebsite.Controllers.Api;
using ECommerceWebsite.Dtos;
using ECommerceWebsite.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace ECommerceWebsite.Tests.Controllers.Api
{
    [TestClass]
    public class CustomerAdminControllerTest
    {
        [TestMethod]
        public void GetCustomer()
        {
            CustomerAdminController controller = new CustomerAdminController();
            CustomerDto result = controller.GetCustomer(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ToggleCustomerActivity()
        {
            CustomerAdminController controller = new CustomerAdminController();
            CustomerDto result = controller.ToggleCustomerActivity(2);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCustomerOrders()
        {
            CustomerAdminController controller = new CustomerAdminController();
            IEnumerable<OrderDto> result = controller.GetCustomerOrders(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UpdateOrder()
        {
            CustomerAdminController controller = new CustomerAdminController();
            OrderDto orderDto = new OrderDto();
            orderDto.Id = 1; orderDto.Quantity = 2; orderDto.SubTotal = 200;
            IHttpActionResult result = controller.UpdateOrder(1, orderDto);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DeleteOrder()
        {
            CustomerAdminController controller = new CustomerAdminController();
            IHttpActionResult result = controller.DeleteOrder(5);
            Assert.IsNotInstanceOfType(result, typeof(OkResult));
        }
    }
}
