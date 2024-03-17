using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.DTOModels
{
    [NotMapped]
    public class InventoryCarPartLogDTO
    {
        public int InventoryCarPartLogId { get; set; }
        public int CarPartId { get; set; }
        public CarPartDTO CarPart { get; set; }
        public int NumberOfParts { get; set; }
        public bool IsValid { get; set; }
    }
}
