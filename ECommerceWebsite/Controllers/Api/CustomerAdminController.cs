using ECommerceWebsite.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ECommerceWebsite.Dtos;
using AutoMapper;

namespace ECommerceWebsite.Controllers.Api
{
    [Authorize(Roles = "Admin")]
    public class CustomerAdminController : ApiController
    {
        private object thisLock = new object();
        private ApplicationDbContext _context;

        public CustomerAdminController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customer/id
        public CustomerDto GetCustomer(int id)
        {
            var customerDto = _context.Customers.Select(Mapper.Map<Customer, CustomerDto>).SingleOrDefault(c => c.Id == id);

            if (customerDto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customerDto;
        }

        // PUT /api/customer/toggleactivity/id
        [HttpPut]
        [Route("~/api/Customer/ToggleActivity/{id}")]
        public CustomerDto ToggleCustomerActivity(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = _context.Customers.Include(c => c.UserProfile).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customer.UserProfile.Active = !customer.UserProfile.Active;
            _context.SaveChanges();

            var customerDto = Mapper.Map<Customer, CustomerDto>(customer);

            return customerDto;
        }

        // GET /api/customer/getorders/id
        [Route("~/api/Customer/GetOrders/{id}")]
        public IEnumerable<OrderDto> GetCustomerOrders(int id)
        {
            var customer = _context.Customers.Single(
                c => c.Id == id);

            var ordersQuery = _context.Orders
                .Include(o => o.Customer)
                .Where(o => o.Customer.Id == customer.Id);

            var orders = ordersQuery.ToList();

            if (orders == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var ordersDtos = new List<OrderDto>();

            foreach (var order in orders)
                ordersDtos.Add(Mapper.Map<OrderDto>(order));

            return ordersDtos;
        }

        // PUT /api/customer/UpdateOrder/id
        [HttpPut]
        [Route("~/api/Customer/UpdateOrder/{id}")]
        public IHttpActionResult UpdateOrder(int id, OrderDto orderDto)
        {
            lock (thisLock)
            {
                var order = _context.Orders.Include(o => o.Product).Include(o => o.Customer).Include(o => o.Customer.UserProfile).Single(o => o.Id == id);

                var productStock = order.Product.NumberOfItemsAvailable;
                var productPrice = order.Product.Price;
                var quantityDifference = orderDto.Quantity - order.Quantity;
                var newStockFigure = productStock - quantityDifference;

                if (newStockFigure < 0)
                    return BadRequest("Not enough product in stock");

                order.Quantity = orderDto.Quantity;
                order.SubTotal = productPrice * orderDto.Quantity;
                order.Product.NumberOfItemsAvailable = newStockFigure;
                _context.SaveChanges();
            }
            return Ok();
        }

        // DELETE /api/customer/RemoveOrder/id
        [HttpDelete]
        [Route("~/api/Customer/RemoveOrder/{id}")]
        public IHttpActionResult DeleteOrder(int id)
        {
            lock (thisLock)
            {
                var order = _context.Orders.Include(o => o.Product).Single(o => o.Id == id);

                var productStock = order.Product.NumberOfItemsAvailable;
                var newStockFigure = order.Quantity + productStock;

                order.Product.NumberOfItemsAvailable = newStockFigure;
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}
