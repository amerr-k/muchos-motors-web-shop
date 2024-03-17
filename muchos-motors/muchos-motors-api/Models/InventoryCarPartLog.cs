using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.Models
{
    public class InventoryCarPartLog
    {
        [Key]
        public int InventoryCarPartLogId { get; set; }

        public int InventoryLogId { get; set; }
        [ForeignKey("InventoryLogId")]
        public InventoryLog InventoryLog { get; set; }

        public int CarPartId { get; set; }
        [ForeignKey("CarPartId")]
        public CarPart CarPart { get; set; }
        public int NumberOfParts { get; set; }
        public bool IsValid { get; set; }


    }
}
