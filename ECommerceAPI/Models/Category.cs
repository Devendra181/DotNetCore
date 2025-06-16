using System.ComponentModel.DataAnnotations;
namespace ECommerceAPI.Models
{
    public class Category
    {
        public int Id { get; set; } //PK
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
