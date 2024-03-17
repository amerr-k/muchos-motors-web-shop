using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Models;
using muchos_motors_api.Services;
using muchos_motors_api.PaginationHelper;
using System.Threading;
using muchos_motors_api.AuthHelper;

namespace muchos_motors_api.Controllers.CarPart
{
    [Route("api/car-parts")]
    [ApiController]
    public class CarPartController : ControllerBase
    {
        private readonly CarPartService carPartService;
        private readonly AuthenticationService authenticationService;


        public CarPartController(CarPartService carPartService,
            AuthenticationService authenticationService)
        {
            this.carPartService = carPartService;
            this.authenticationService = authenticationService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList>> GetAllCarParts([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? searchTerm = null, [FromQuery] CarPartFilterDTO carPartFilterDTO = null, CancellationToken cancellationToken = default)
        {
            var carPartList = await carPartService.GetAllCarPartsAsync(page, pageSize, searchTerm, carPartFilterDTO, cancellationToken);
            return carPartList;
        }


        [HttpGet("{carPartId}")]
        public async Task<ActionResult<CarPartDTO>> GetCarPartById([FromRoute] int carPartId)
        {
            var carPart = await carPartService.GetCarPartByIdAsync(carPartId);
            return carPart;
        }

        [HttpPost]
        [EmployeeFilter]
        public async Task<ActionResult> CreateCarPart([FromBody] CarPartDTO carPartDto, CancellationToken cancellationToken)
        {
            var createdCarPart = await carPartService.CreateCarPartAsync(carPartDto, cancellationToken);
            return CreatedAtAction(nameof(GetCarPartById), new { carPartId = createdCarPart.CarPartId }, createdCarPart);
        }

        [HttpPut]
        [EmployeeFilter]
        public async Task<IActionResult> UpdateCarPart([FromBody] CarPartDTO carPartDto, CancellationToken cancelationToken)
        {
            await carPartService.UpdateCarPartAsync(carPartDto, cancelationToken);
            return NoContent();
        }

        [HttpDelete("{carPartId}")]
        [EmployeeFilter]
        public async Task<ActionResult> DeleteCarPart([FromRoute] int carPartId)
        {
            await carPartService.DeleteCarPartAsync(carPartId);
            return NoContent();
        }

        [HttpGet("without-pagination")]
        [EmployeeFilter]
        public async Task<ActionResult<List<CarPartDTO>>> GetAllCarPartsWithoutPagination(CancellationToken cancellationToken = default)
        {
            return await carPartService.GetAllCarPartsWithoutPagination(cancellationToken);
        }
    }
}
