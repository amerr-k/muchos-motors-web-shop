using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.DTOModels
{
    [NotMapped]
    public class InventoryLogDTO
    {
        public int? InventoryLogId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public List<InventoryCarPartLogDTO> InventoryCarPartLogs { get; set; }
        public bool? IsValid { get; set; }
    }
}
