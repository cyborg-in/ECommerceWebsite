using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(0.0, 50000.0f)]
        public float Price { get; set; }

        [Required]
        [Range(0, 200)]
        public int NumberOfItemsAvailable { get; set; }
    }
}