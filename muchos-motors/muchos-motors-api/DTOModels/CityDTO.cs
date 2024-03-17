
using System.ComponentModel.DataAnnotations.Schema;

namespace muchos_motors_api.DTOModels
{
    [NotMapped]
    public class CityDTO
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public bool IsValid { get; set; }

    }
}
