using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.DTOModels
{
    [NotMapped]
    public class OrderItemDTO
    {
        public int OrderItemId { get; set; }
        public int CarPartId { get; set; }
        public CarPartDTO CarPart { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsValid { get; set; }

    }
}
