using Microsoft.EntityFrameworkCore;
using muchos_motors_api.DTOModels;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.Models;
using muchos_motors_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace muchos_motors_api.EntityFramework.Repositories
{
    public class InventoryCarPartLogRepository
    {
        private readonly DataDbContext dataDbContext;

        public InventoryCarPartLogRepository(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        public async Task<List<InventoryCarPartLog>> GetAllInventoryCarPartLogsAscAsync(CancellationToken cancellationToken)
        {
            return await dataDbContext.InventoryCarPartLog
                .Where(inventoryCarPartLog => inventoryCarPartLog.IsValid)
                .ToListAsync(cancellationToken);
        }

        public async Task<InventoryCarPartLog> GetInventoryCarPartLogByIdAsync(int inventoryCarPartLogId)
        {
            return await dataDbContext.InventoryCarPartLog
                .FirstOrDefaultAsync(o => o.InventoryCarPartLogId == inventoryCarPartLogId && o.IsValid);
        }

        public void DeleteByObject(InventoryCarPartLog inventoryCarPartLog)
        {
            inventoryCarPartLog.IsValid = false;
        }

        public async Task<InventoryCarPartLog> CreateInventoryCarPartLogAsync(int inventoryLogId, InventoryCarPartLogDTO inventoryCarPartLogDto, CancellationToken cancellationToken)
        {
            var inventoryCarPartLog = new InventoryCarPartLog
            {
                InventoryLogId = inventoryLogId,
                CarPartId = inventoryCarPartLogDto.CarPartId,
                NumberOfParts = inventoryCarPartLogDto.NumberOfParts,
                IsValid = true,
            };
            await dataDbContext.AddAsync(inventoryCarPartLog, cancellationToken);
            return inventoryCarPartLog;
        }

        public async Task<List<InventoryCarPartLog>> GetAllInventoryCarPartLogsAscByIdAsync(int inventoryLogId, CancellationToken cancellationToken)
        {
            return await dataDbContext.InventoryCarPartLog
                .Include(x => x.CarPart)
                .Where(inventoryCarPartLog => inventoryCarPartLog.IsValid
                && inventoryCarPartLog.InventoryLogId == inventoryLogId)
                .ToListAsync(cancellationToken);
        }
    }
}
