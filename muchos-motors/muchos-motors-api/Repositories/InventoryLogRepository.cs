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
    public class InventoryLogRepository
    {
        private readonly DataDbContext dataDbContext;
        private readonly AuthenticationService authenticationService;

        public InventoryLogRepository(DataDbContext dataDbContext, AuthenticationService authenticationService)
        {
            this.dataDbContext = dataDbContext;
            this.authenticationService = authenticationService;
        }

        public async Task<List<InventoryLog>> GetAllInventoryLogsAscAsync(CancellationToken cancellationToken)
        {
            return await dataDbContext.InventoryLog
                .Where(inventoryLog => inventoryLog.IsValid)
                .OrderBy(inventoryLog => inventoryLog.CreatedDate)
                .ToListAsync(cancellationToken);
        }

        public async Task<InventoryLog> GetInventoryLogByIdAsync(int inventoryLogId)
        {
            return await dataDbContext.InventoryLog
                .FirstOrDefaultAsync(o => o.InventoryLogId == inventoryLogId && o.IsValid);
        }

        public void DeleteByObject(InventoryLog inventoryLog)
        {
            inventoryLog.IsValid = false;
        }

        public async Task<InventoryLog> CreateInventoryLogAsync(CancellationToken cancellationToken)
        {
            var userAccount = authenticationService.GetUserAuthInfo().UserAccount;
            var userName = userAccount != null ? userAccount.Username : "";
            var inventoryLog = new InventoryLog
            {
                CreatedBy = userName,
                CreatedDate = DateTime.Now,
                IsValid = true,
            };
            await dataDbContext.AddAsync(inventoryLog, cancellationToken);
            return inventoryLog;
        }

    }
}
