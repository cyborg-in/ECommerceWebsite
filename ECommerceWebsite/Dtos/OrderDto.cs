using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        [Required]
        [Range(0, 100)]
        public int Quantity { get; set; }

        [Required]
        public float SubTotal { get; set; }
    }
}