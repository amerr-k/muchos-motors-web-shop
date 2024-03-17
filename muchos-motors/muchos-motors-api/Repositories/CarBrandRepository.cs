using Microsoft.EntityFrameworkCore;
using muchos_motors_api.DTOModels;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace muchos_motors_api.EntityFramework.Repositories
{
    public class CarBrandRepository
    {
        private readonly DataDbContext dataDbContext;

        public CarBrandRepository(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        public async Task<List<CarBrand>> GetAllCarBrandsAscAsync()
        {
            return await dataDbContext.CarBrand
                .Where(carBrand => carBrand.IsValid)
                .OrderBy(carBrand => carBrand.Name)
                .ToListAsync();
        }

        public async Task<CarBrand> GetCarBrandByIdAsync(int carBrandId)
        {
            return await dataDbContext.CarBrand
                .FirstOrDefaultAsync(o => o.CarBrandId == carBrandId && o.IsValid);
        }

        public void DeleteByObject(CarBrand carBrand)
        {
            carBrand.IsValid = false;
        }

        public async Task<CarBrand> CreateCarBrandAsync(CarBrandDTO carBrandDto)
        {
            var carBrand = new CarBrand
            {
                Name = carBrandDto.Name,
                IsValid = true
            };
            await dataDbContext.AddAsync(carBrand);
            return carBrand;
        }

        public void UpdateCarBrand(CarBrand existingCarBrand, CarBrandDTO carBrandDto)
        {
            existingCarBrand.Name = carBrandDto.Name;
        }
    }
}
