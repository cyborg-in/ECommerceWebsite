using ECommerceWebsite.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        public ViewResult AllUsers()
        {
            var users = _context.Customers.Include(c => c.UserProfile).ToList();
            AdminCustomerViewModel viewmodel = new AdminCustomerViewModel();
            viewmodel.Customers = users;
            return View(viewmodel);
        }

        public ViewResult GetUserOrders(int id)
        {
            var orders = _context.Orders.Include(o => o.Customer).Include(o => o.Product).Where(o => o.Customer.Id == id).ToList();
            AdminOrderViewModel viewmodel = new AdminOrderViewModel();
            viewmodel.Orders = orders;
            return View(viewmodel);
        }

        public ViewResult GetOrderSummary(int orderNumber)
        {
            var orders = _context.Orders.Include(o => o.Product).Where(o => o.OrderNumber == orderNumber).ToList();
            AdminOrderViewModel viewmodel = new AdminOrderViewModel();
            float total = 0.0f;
            if (orders.Count > 0)
            {
                foreach (var order in orders)
                {
                    total += order.SubTotal;
                }
            }
            viewmodel.Orders = orders;
            viewmodel.Total = total;
            return View(viewmodel);
        }
    }
}