using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.Models
{
    public class CarPartsCompatibility
    {
        [Key]
        public int CarPartsCompatibilityId { get; set; }

        public int CarPartId { get; set; }
        [ForeignKey("CarPartId")]
        public CarPart CarPart { get; set; }

        public int GenericCarModelId { get; set; }
        [ForeignKey("GenericCarModelId")]
        public GenericCarModel GenericCarModel { get; set; }
        public bool IsValid { get; set; }

    }
}
