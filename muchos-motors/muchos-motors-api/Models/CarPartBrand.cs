using System.ComponentModel.DataAnnotations;

namespace muchos_motors_api.Models
{
    public class CarPartBrand
    {
        [Key]
        public int CarPartBrandId { get; set; }
        public string Name { get; set; }
        public bool IsValid { get; set; }

    }
}
