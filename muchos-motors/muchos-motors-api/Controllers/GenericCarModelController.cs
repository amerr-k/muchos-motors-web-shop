using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using muchos_motors_api.AuthHelper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Models;
using muchos_motors_api.Services;

namespace muchos_motors_api.Controllers.GenericCarModel
{
    [Route("api/generic-car-models")]
    [ApiController]
    public class GenericCarModelController : ControllerBase
    {
        private readonly GenericCarModelService genericCarModelService;

        public GenericCarModelController(GenericCarModelService genericCarModelService)
        {
            this.genericCarModelService = genericCarModelService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenericCarModelDTO>>> GetAllGenericCarModels()
        {
            var genericCarModelList = await genericCarModelService.GetAllGenericCarModelsAsync();
            return genericCarModelList;
        }

        [HttpGet("{genericCarModelId}")]
        public async Task<ActionResult<GenericCarModelDTO>> GetGenericCarModelById([FromRoute] int genericCarModelId)
        {
            var genericCarModel = await genericCarModelService.GetGenericCarModelByIdAsync(genericCarModelId);
            return genericCarModel;
        }

        [HttpPost]
        [EmployeeFilter]
        public async Task<ActionResult> CreateGenericCarModel([FromBody] GenericCarModelDTO genericCarModelDto)
        {
            var createdGenericCarModel = await genericCarModelService.CreateGenericCarModelAsync(genericCarModelDto);
            return CreatedAtAction(nameof(GetGenericCarModelById), new { genericCarModelId = createdGenericCarModel.GenericCarModelId }, createdGenericCarModel);
        }

        [HttpPut]
        [EmployeeFilter]
        public async Task<IActionResult> UpdateGenericCarModel([FromBody] GenericCarModelDTO genericCarModelDto)
        {
            await genericCarModelService.UpdateGenericCarModelAsync(genericCarModelDto);
            return NoContent();
        }

        [HttpDelete("{genericCarModelId}")]
        [EmployeeFilter]
        public async Task<ActionResult> DeleteGenericCarModel([FromQuery] int genericCarModelId)
        {
            await genericCarModelService.DeleteGenericCarModelAsync(genericCarModelId);
            return NoContent();
        }
    }
}
