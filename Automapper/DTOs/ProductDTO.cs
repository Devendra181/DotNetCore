using System.ComponentModel.DataAnnotations;
namespace AutomapperDemo.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public string Category { get; set; }
        // Note: Excluding SupplierCost, SupplierInfo, and StockQuantity for security reasons
    }
}
