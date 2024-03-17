using muchos_motors_api.EntityFramework.Repositories;
using AutoMapper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace muchos_motors_api.Services
{
    public class CarBrandService
    {
        private readonly DataDbContext dataDbContext;
        private readonly CarBrandRepository carBrandRepository;
        private readonly Mapper mapper;
        private readonly AuthenticationService authenticationService;

        public CarBrandService(DataDbContext dataDbContext, CarBrandRepository carBrandRepository, Mapper mapper, AuthenticationService authenticationService)
        {
            this.dataDbContext = dataDbContext;
            this.carBrandRepository = carBrandRepository;
            this.mapper = mapper;
            this.authenticationService = authenticationService;
        }

        public async Task<List<CarBrandDTO>> GetAllCarBrandsAsync()
        {
            var carBrandList = await carBrandRepository.GetAllCarBrandsAscAsync();
            return mapper.Map<List<CarBrandDTO>>(carBrandList);
        }

        public async Task<CarBrandDTO> GetCarBrandByIdAsync(int carBrandId)
        {
            var carBrand = await carBrandRepository.GetCarBrandByIdAsync(carBrandId);
            if (carBrand == null)
            {
                throw new AppException($"CarBrand with ID {carBrandId} not found", (int)HttpStatusCode.NotFound);
            }
            return mapper.Map<CarBrandDTO>(carBrand);
        }

        public async Task DeleteCarBrandAsync(int carBrandId)
        {
            var carBrand = await carBrandRepository.GetCarBrandByIdAsync(carBrandId);
            if (carBrand == null)
            {
                throw new AppException($"CarBrand with ID {carBrandId} not found");
            }
            carBrandRepository.DeleteByObject(carBrand);
            await dataDbContext.SaveChangesAsync();
        }

        public async Task<CarBrand> CreateCarBrandAsync(CarBrandDTO carBrandDto)
        {
            ValidateCarBrandDto(carBrandDto);

            var createdCarBrand = await carBrandRepository.CreateCarBrandAsync(carBrandDto);
            await dataDbContext.SaveChangesAsync();
            return createdCarBrand;
        }

        public async Task UpdateCarBrandAsync(CarBrandDTO carBrandDto)
        {
            ValidateCarBrandDto(carBrandDto);

            var existingCarBrand = await carBrandRepository.GetCarBrandByIdAsync(carBrandDto.CarBrandId);
            if (existingCarBrand == null)
            {
                throw new AppException($"CarBrand with ID {carBrandDto.CarBrandId} not found");
            }

            carBrandRepository.UpdateCarBrand(existingCarBrand, carBrandDto);
            await dataDbContext.SaveChangesAsync();
        }

        private void ValidateCarBrandDto(CarBrandDTO carBrandDto)
        {
            // Add any validation logic specific to CarBrandDTO
            // You can use ValidationUtils or other validation methods here.
        }
    }
}