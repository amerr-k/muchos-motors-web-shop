using System.ComponentModel.DataAnnotations;

namespace muchos_motors_api.Models
{
    public class CarBrand
    {
        [Key]
        public int CarBrandId { get; set; }
        public string Name { get; set; }
        public bool IsValid { get; set; }

    }
}
