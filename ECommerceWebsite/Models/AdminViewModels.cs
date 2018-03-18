using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWebsite.Models
{
    public class AdminCustomerViewModel
    {
        [Required]
        public List<Customer> Customers { get; set; }
    }

    public class AdminOrderViewModel
    {
        [Required]
        public List<Order> Orders { get; set; }

        [Range(0.0, 9999999999.99)]
        public float Total { get; set; }
    }
}