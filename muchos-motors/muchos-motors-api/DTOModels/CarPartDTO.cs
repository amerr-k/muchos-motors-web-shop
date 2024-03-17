using muchos_motors_api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.DTOModels
{
    [NotMapped]
    public class CarPartDTO
    {
        public int CarPartId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int WarehouseCount { get; set; }
        public string Details { get; set; }
        public string CarPartCategory { get; set; }
        public string? Base64Image { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsValid { get; set; }
    }
}
