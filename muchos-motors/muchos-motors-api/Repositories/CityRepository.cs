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
    public class CityRepository
    {
        private readonly DataDbContext dataDbContext;

        public CityRepository(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        public async Task<List<City>> GetAllCitiesAscAsync()
        {
            return await dataDbContext.City
                .Where(city => city.IsValid)
                .OrderBy(city => city.Name)
                .ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(int cityId)
        {
            return await dataDbContext.City
                .FirstOrDefaultAsync(o => o.CityId == cityId && o.IsValid);
        }

        public void DeleteByObject(City city)
        {
            city.IsValid = false;
        }

        public async Task<City> CreateCityAsync(CityDTO cityDto)
        {
            var city = new City
            {
                Name = cityDto.Name,
                IsValid = true
            };
            await dataDbContext.AddAsync(city);
            return city;
        }

        public void UpdateCity(City existingCity, CityDTO cityDto)
        {
            existingCity.Name = cityDto.Name;
        }
    }
}
