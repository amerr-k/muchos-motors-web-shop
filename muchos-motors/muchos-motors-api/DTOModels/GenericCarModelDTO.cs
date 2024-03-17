using muchos_motors_api.Enums;
using muchos_motors_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.DTOModels
{
    [NotMapped]
    public class GenericCarModelDTO
    {
        public int GenericCarModelId { get; set; }
        public string GenerationName { get; set; }
        public string ModelName { get; set; }
        public int CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }
        public int ProductionStartYear { get; set; }
        public int ProductionEndYear { get; set; }
        public bool IsValid { get; set; }

    }
}
