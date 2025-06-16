using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ECommerceAPI.Models
{
    public class Order
    {
        public int Id { get; set; } //PK
        [Required]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } //Base Amount
        [Column(TypeName = "decimal(18,2)")]
        public decimal OrderDiscount { get; set; } //Order Level Discount
        [Column(TypeName = "decimal(18,2)")]
        public decimal DeliveryCharge { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }
        [MaxLength(20)]
        public string Status { get; set; }
        public DateTime? ShippedDate { get; set; }
        [Required]
        public int? CustomerId { get; set; } //FK
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public TrackingDetail TrackingDetail { get; set; }
        public int? ShippingAddressId { get; set; } //FK
        [ForeignKey("ShippingAddressId")]
        public Address ShippingAddres { get; set; }
    }
}
