using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ECommerceAPI.Models
{
    public class TrackingDetail
    {
        public int Id { get; set; } //PK
        public int OrderId { get; set; } //FK
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [Required]
        public string Carrier { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        [MaxLength(500)]
        public string TrackingNumber { get; set; }
    }
}
