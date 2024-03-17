using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using muchos_motors_api.AuthHelper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Services;

namespace muchos_motors_api.Controllers.InventoryLog
{
    [Route("api/inventory-log")]
    [ApiController]
    [LoginFilter]
    public class InventoryLogController : ControllerBase
    {
        private readonly InventoryLogService inventoryLogService;

        public InventoryLogController(InventoryLogService inventoryLogService)
        {
            this.inventoryLogService = inventoryLogService;
        }

        [HttpGet]
        [EmployeeFilter]
        public async Task<ActionResult<List<InventoryLogDTO>>> GetAllInventoryLogs(CancellationToken cancellationToken)
        {
            return await inventoryLogService.GetAllInventoryLogsAsync(cancellationToken);
        }

        [HttpGet("{inventoryLogId}")]
        [EmployeeFilter]
        public async Task<ActionResult<InventoryLogDTO>> GetInventoryLogById([FromRoute] int inventoryLogId, CancellationToken cancellationToken)
        {
            return await inventoryLogService.GetInventoryLogByIdAsync(inventoryLogId, cancellationToken);
        }

        [HttpPost]
        [EmployeeFilter]
        public async Task<ActionResult> CreateInventoryLog([FromBody] InventoryLogDTO inventoryLogDto, CancellationToken cancellationToken)
        {
            var createdInventoryLog = await inventoryLogService.CreateInventoryLogAsync(inventoryLogDto, cancellationToken);
            return CreatedAtAction(nameof(GetInventoryLogById), new { inventoryLogId = createdInventoryLog.InventoryLogId }, createdInventoryLog);
        }

        [HttpDelete("{inventoryLogId}")]
        [EmployeeFilter]
        public async Task<ActionResult> DeleteInventoryLog([FromQuery] int inventoryLogId)
        {
            await inventoryLogService.DeleteInventoryLogAsync(inventoryLogId);
            return NoContent();
        }
    }
}
