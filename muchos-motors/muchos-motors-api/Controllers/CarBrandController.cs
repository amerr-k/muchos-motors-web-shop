using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using muchos_motors_api.AuthHelper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Services;

namespace muchos_motors_api.Controllers.CarBrand
{
    [Route("api/car-brands")]
    [ApiController]
    public class CarBrandController : ControllerBase
    {
        private readonly CarBrandService carBrandService;
        private readonly AuthenticationService authenticationService;

        public CarBrandController(CarBrandService carBrandService,
            AuthenticationService authenticationService)
        {
            this.carBrandService = carBrandService;
            this.authenticationService = authenticationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarBrandDTO>>> GetAllCarBrands()
        {
            var carBrandList = await carBrandService.GetAllCarBrandsAsync();
            return carBrandList;
        }

        [HttpGet("{carBrandId}")]
        public async Task<ActionResult<CarBrandDTO>> GetCarBrandById([FromRoute] int carBrandId)
        {


            var carBrand = await carBrandService.GetCarBrandByIdAsync(carBrandId);
            return carBrand;
        }

        [HttpPost]
        [EmployeeFilter]
        public async Task<ActionResult> CreateCarBrand([FromBody] CarBrandDTO carBrandDto)
        {
            var createdCarBrand = await carBrandService.CreateCarBrandAsync(carBrandDto);
            return CreatedAtAction(nameof(GetCarBrandById), new { carBrandId = createdCarBrand.CarBrandId }, createdCarBrand);
        }

        [HttpPut]
        [EmployeeFilter]
        public async Task<IActionResult> UpdateCarBrand([FromBody] CarBrandDTO carBrandDto)
        {
            await carBrandService.UpdateCarBrandAsync(carBrandDto);
            return NoContent();
        }

        [HttpDelete("{carBrandId}")]
        [EmployeeFilter]
        public async Task<ActionResult> DeleteCarBrand([FromQuery] int carBrandId)
        {
            await carBrandService.DeleteCarBrandAsync(carBrandId);
            return NoContent();
        }
    }
}
