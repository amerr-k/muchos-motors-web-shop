using muchos_motors_api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.DTOModels
{
    [NotMapped]
    public class CarBrandDTO
    {
        public int CarBrandId { get; set; }
        public string Name { get; set; }
        public bool IsValid { get; set; }

    }
}
