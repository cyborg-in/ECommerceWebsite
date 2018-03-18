using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int OrderNumber { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        [Range(0, 100)]
        public int Quantity { get; set; }

        [Required]
        [Range(0.0, 500000.0)]
        public float SubTotal { get; set; }
    }
}