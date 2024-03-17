using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using muchos_motors_api.AuthHelper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Services;

namespace muchos_motors_api.Controllers.City
{
    [Route("api/cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CityService cityService;

        public CityController(CityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CityDTO>>> GetAllCities()
        {
            var cityList = await cityService.GetAllCitiesAsync();
            return cityList;
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<CityDTO>> GetCityById([FromRoute] int cityId)
        {
            var city = await cityService.GetCityByIdAsync(cityId);
            return city;
        }

        [HttpPost]
        [EmployeeFilter]
        public async Task<ActionResult> CreateCity([FromBody] CityDTO cityDto)
        {
            var createdCity = await cityService.CreateCityAsync(cityDto);
            return CreatedAtAction(nameof(GetCityById), new { cityId = createdCity.CityId }, createdCity);
        }

        [HttpPut]
        [EmployeeFilter]
        public async Task<IActionResult> UpdateCity([FromBody] CityDTO cityDto)
        {
            await cityService.UpdateCityAsync(cityDto);
            return NoContent();
        }

        [HttpDelete("{cityId}")]
        [EmployeeFilter]
        public async Task<ActionResult> DeleteCity([FromQuery] int cityId)
        {
            await cityService.DeleteCityAsync(cityId);
            return NoContent();
        }
    }
}
