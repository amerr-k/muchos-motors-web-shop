using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.Models
{
    public class InventoryLog
    {
        [Key]
        public int InventoryLogId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsValid { get; set; }

    }
}
