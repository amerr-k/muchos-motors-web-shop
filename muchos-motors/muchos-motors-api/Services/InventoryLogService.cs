using muchos_motors_api.EntityFramework.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Models;
using muchos_motors_api.Utils;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.AspNetCore.Mvc;

namespace muchos_motors_api.Services
{
    public class InventoryLogService
    {
        private readonly DataDbContext dataDbContext;
        private readonly InventoryLogRepository inventoryLogRepository;
        private readonly InventoryCarPartLogRepository inventoryCarPartLogRepository;
        private readonly CarPartService carPartService;
        private readonly Mapper mapper;

        public InventoryLogService(DataDbContext dataDbContext,
            InventoryLogRepository inventoryLogRepository,
            InventoryCarPartLogRepository inventoryCarPartLogRepository,
            CarPartService carPartService,
            Mapper mapper)
        {
            this.dataDbContext = dataDbContext;
            this.inventoryLogRepository = inventoryLogRepository;
            this.inventoryCarPartLogRepository = inventoryCarPartLogRepository;
            this.carPartService = carPartService;
            this.mapper = mapper;
        }

        public async Task<List<InventoryLogDTO>> GetAllInventoryLogsAsync(CancellationToken cancellationToken)
        {
            var inventoryLogList = await inventoryLogRepository.GetAllInventoryLogsAscAsync(cancellationToken);
            return mapper.Map<List<InventoryLogDTO>>(inventoryLogList);
        }

        public async Task<InventoryLogDTO> GetInventoryLogByIdAsync(int inventoryLogId, CancellationToken cancellationToken)
        {
            var inventoryLog = await inventoryLogRepository.GetInventoryLogByIdAsync(inventoryLogId);
            if (inventoryLog == null)
            {
                throw new AppException($"InventoryLog with ID {inventoryLogId} not found", (int)HttpStatusCode.NotFound);
            }
            var inventoryLogsDto = mapper.Map<InventoryLogDTO>(inventoryLog);

            var inventoryCarPartLogs = await inventoryCarPartLogRepository.GetAllInventoryCarPartLogsAscByIdAsync(inventoryLog.InventoryLogId, cancellationToken);

            inventoryLogsDto.InventoryCarPartLogs = mapper.Map< List<InventoryCarPartLogDTO>>(inventoryCarPartLogs);
            return inventoryLogsDto;
        }

        public async Task DeleteInventoryLogAsync(int inventoryLogId)
        {
            var inventoryLog = await inventoryLogRepository.GetInventoryLogByIdAsync(inventoryLogId);
            if (inventoryLog == null)
            {
                throw new AppException($"InventoryLog with ID {inventoryLogId} not found");
            }
            inventoryLogRepository.DeleteByObject(inventoryLog);
            await dataDbContext.SaveChangesAsync();
        }

        public async Task<InventoryLog> CreateInventoryLogAsync(InventoryLogDTO inventoryLogDto, CancellationToken cancellationToken)
        {
            ValidateInventoryLogDto(inventoryLogDto);

            var createdInventoryLog = await inventoryLogRepository.CreateInventoryLogAsync(cancellationToken);
            await dataDbContext.SaveChangesAsync();

            await CreateInventoryCarPartLogs(createdInventoryLog.InventoryLogId, inventoryLogDto.InventoryCarPartLogs, cancellationToken);

            await dataDbContext.SaveChangesAsync();
            return createdInventoryLog;
        }

        private async Task CreateInventoryCarPartLogs(int inventoryLogId, List<InventoryCarPartLogDTO> inventoryCarPartLogs, CancellationToken cancellationToken)
        {
            foreach (var item in inventoryCarPartLogs)
            {
                await inventoryCarPartLogRepository.CreateInventoryCarPartLogAsync(inventoryLogId, item, cancellationToken);
                await carPartService.UpdateCarPartQuantityAsync(item.CarPartId, item.NumberOfParts);
            }
            await dataDbContext.SaveChangesAsync(cancellationToken);
        }

        private void ValidateInventoryLogDto(InventoryLogDTO inventoryLogDto)
        {
            if (!ValidationUtils.IsNotNull(inventoryLogDto))
            {
                throw new AppException("One or more required inventoryLog attributes are null");
            }
        }

    }
}
