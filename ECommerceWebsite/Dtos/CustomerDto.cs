using System.ComponentModel.DataAnnotations;

namespace ECommerceWebsite.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}