using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using muchos_motors_api.Enums;

namespace muchos_motors_api.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string ChasisNumber { get; set; }
        public string LicencePlate { get; set; }
        public int YearOfManufacture { get; set; }
        public string Color { get; set; }
        public string Transmission { get; set; }
        public double EngineSize { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Mileage { get; set; }
        public CarTrim Trim { get; set; }
        public CarSegment Segment { get; set; }
        public int GenericGenerationCarModelId { get; set; }
        [ForeignKey("GenericGenerationCarModelId")]
        public GenericCarModel GenericGenerationCarModel { get; set; }
        public bool IsValid { get; set; }

    }
}
