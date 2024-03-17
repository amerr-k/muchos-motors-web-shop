using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.Models
{
    public class GenericCarModel
    {
        [Key]
        public int GenericCarModelId { get; set; }
        public string GenerationName { get; set; }
        public string ModelName { get; set; }
        public int CarBrandId { get; set; }
        [ForeignKey("CarBrandId")]
        public CarBrand CarBrand { get; set; }
        public int ProductionStartYear { get; set; }
        public int ProductionEndYear { get; set; }
        public bool IsValid { get; set; }
    }
}
