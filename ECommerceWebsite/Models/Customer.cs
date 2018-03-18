using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public ApplicationUser UserProfile { get; set; }
    }
}