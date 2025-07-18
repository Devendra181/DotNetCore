﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ECommerceAPI.Models
{
    public class MembershipTier
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string TierName { get; set; } // e.g., Gold, Silver, Bronze
        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercentage { get; set; } // Discount percentage for this tier
    }
}
