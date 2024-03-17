using muchos_motors_api.EntityFramework.Repositories;
using AutoMapper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using muchos_motors_api.PaginationHelper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace muchos_motors_api.Services
{
    public class CarPartService
    {
        private readonly DataDbContext dataDbContext;
        private readonly CarPartRepository carPartRepository;
        private readonly Mapper mapper;
        private readonly IConfiguration configuration;
        private readonly ImageService imageService;
        private static string CAR_PART_FOLDER_PATH;

        public CarPartService(DataDbContext dataDbContext,
            CarPartRepository carPartRepository,
            Mapper mapper,
            IConfiguration configuration,
            ImageService imageService)
        {
            this.dataDbContext = dataDbContext;
            this.carPartRepository = carPartRepository;
            this.mapper = mapper;
            this.configuration = configuration;
            this.imageService = imageService;
            if (CAR_PART_FOLDER_PATH == null)
            {
                CAR_PART_FOLDER_PATH = this.configuration["FolderPaths:CarPartPath"];
            }
        }

        public async Task<PagedList> GetAllCarPartsAsync(int page, int pageSize, string searchTerm, CarPartFilterDTO carPartFilterDto, CancellationToken cancellationToken)
        {

            IQueryable<CarPart> carPartListQuery;
            if (carPartFilterDto != null && (carPartFilterDto.SelectedGenericCarModelId != null || carPartFilterDto.SelectedCarBrandId != null))
            {
                carPartListQuery = carPartRepository.GetAllCarPartsAscByFilter(searchTerm, carPartFilterDto);
            }
            else
            {
                carPartListQuery = carPartRepository.GetAllCarPartsAscAsync(searchTerm);
            }

            if (page < 1) page = 1;
            var totalCount = carPartListQuery.Count();
            var carPartsPagedList = await carPartListQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);


            var carPartDtoList = mapper.Map<List<CarPartDTO>>(carPartsPagedList);
            var pagedList = new PagedList(carPartDtoList, totalCount, page, pageSize);

            return pagedList;
        }

        public async Task<CarPartDTO> GetCarPartByIdAsync(int carPartId)
        {
            var carPart = await carPartRepository.GetCarPartByIdAsync(carPartId);
            if (carPart == null)
            {
                throw new AppException($"CarPart with ID {carPartId} not found", (int)HttpStatusCode.NotFound);
            }
            return mapper.Map<CarPartDTO>(carPart);
        }

        public async Task DeleteCarPartAsync(int carPartId)
        {
            var carPart = await carPartRepository.GetCarPartByIdAsync(carPartId);
            if (carPart == null)
            {
                throw new AppException($"CarPart with ID {carPartId} not found");
            }
            carPartRepository.DeleteByObject(carPart);
            await dataDbContext.SaveChangesAsync();
        }

        public async Task<ActionResult<List<CarPartDTO>>> GetAllCarPartsWithoutPagination(CancellationToken cancellationToken)
        {
            var carPartList = await carPartRepository.GetAllCarPartsAscAsync().ToListAsync(cancellationToken);
            return mapper.Map<List<CarPartDTO>>(carPartList);
        }

        public async Task<CarPart> CreateCarPartAsync(CarPartDTO carPartDto, CancellationToken cancellationToken)
        {
            ValidateCarPartDto(carPartDto);

            await SaveCarPartImage(carPartDto, cancellationToken);

            var createdCarPart = await carPartRepository.CreateCarPartAsync(carPartDto, cancellationToken);

            await dataDbContext.SaveChangesAsync();
            return createdCarPart;
        }

        public async Task UpdateCarPartQuantityAsync(int carPartId, int quantity)
        {
            var existingCarPart = await carPartRepository.GetCarPartByIdAsync(carPartId);
            if (existingCarPart == null)
            {
                throw new AppException($"CarPart with ID {carPartId} not found");
            }
            carPartRepository.UpdateCarPartQuantity(existingCarPart, quantity);
            await dataDbContext.SaveChangesAsync();
        }

        public async Task UpdateCarPartAsync(CarPartDTO carPartDto, CancellationToken cancellationToken)
        {
            ValidateCarPartDto(carPartDto);

            var existingCarPart = await carPartRepository.GetCarPartByIdAsync(carPartDto.CarPartId);
            if (existingCarPart == null)
            {
                throw new AppException($"CarPart with ID {carPartDto.CarPartId} not found");
            }

            await SaveCarPartImage(carPartDto, cancellationToken);

            carPartRepository.UpdateCarPart(existingCarPart, carPartDto);
            await dataDbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task SaveCarPartImage(CarPartDTO carPartDto, CancellationToken cancellationToken)
        {
            var imageUrl = await imageService.SaveImageAsync(carPartDto.Base64Image, CAR_PART_FOLDER_PATH, cancellationToken) ?? "";
            carPartDto.ImageUrl = imageUrl;
        }

        private void ValidateCarPartDto(CarPartDTO carPartDto)
        {
            
        }
    }
}