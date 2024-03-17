using muchos_motors_api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.Models
{
    public class CarPart
    {
        [Key]
        public int CarPartId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SellingPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }
        public int WarehouseCount { get; set; }
        public string Details { get; set; }
        public CarPartCategory CarPartCategory { get; set; }
        public string ImageUrl { get; set; }
        public bool IsValid { get; set; }
    }
}
