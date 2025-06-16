using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ECommerceAPI.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; } //FK
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; } // Discount applied to this item based on product's discount percentage
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        [Required]
        public int OrderId { get; set; } //FK
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
