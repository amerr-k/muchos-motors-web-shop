using muchos_motors_api.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.DTOModels
{
    [NotMapped]
    public class CarPartFilterDTO
    {
        public int? SelectedCarBrandId { get; set; }
        public int? SelectedGenericCarModelId { get; set; }
    }
}
