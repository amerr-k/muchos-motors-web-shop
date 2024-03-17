using System.ComponentModel.DataAnnotations;

namespace muchos_motors_api.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public bool IsValid { get; set; }

    }
}
