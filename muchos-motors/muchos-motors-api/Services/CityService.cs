using muchos_motors_api.EntityFramework.Repositories;
using AutoMapper;
using muchos_motors_api.DTOModels;
using muchos_motors_api.EntityFramework;
using muchos_motors_api.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
namespace muchos_motors_api.Services
{
    public class CityService
    {
        private readonly DataDbContext dataDbContext;
        private readonly CityRepository cityRepository;
        private readonly Mapper mapper;

        public CityService(DataDbContext dataDbContext, CityRepository cityRepository, Mapper mapper)
        {
            this.dataDbContext = dataDbContext;
            this.cityRepository = cityRepository;
            this.mapper = mapper;
        }

        public async Task<List<CityDTO>> GetAllCitiesAsync()
        {
            var cityList = await cityRepository.GetAllCitiesAscAsync();
            return mapper.Map<List<CityDTO>>(cityList);
        }

        public async Task<CityDTO> GetCityByIdAsync(int cityId)
        {
            var city = await cityRepository.GetCityByIdAsync(cityId);
            if (city == null)
            {
                throw new AppException($"City with ID {cityId} not found", (int)HttpStatusCode.NotFound);
            }
            return mapper.Map<CityDTO>(city);
        }

        public async Task DeleteCityAsync(int cityId)
        {
            var city = await cityRepository.GetCityByIdAsync(cityId);
            if (city == null)
            {
                throw new AppException($"City with ID {cityId} not found");
            }
            cityRepository.DeleteByObject(city);
            await dataDbContext.SaveChangesAsync();
        }

        public async Task<City> CreateCityAsync(CityDTO cityDto)
        {
            ValidateCityDto(cityDto);

            var createdCity = await cityRepository.CreateCityAsync(cityDto);
            await dataDbContext.SaveChangesAsync();
            return createdCity;
        }

        public async Task UpdateCityAsync(CityDTO cityDto)
        {
            ValidateCityDto(cityDto);

            var existingCity = await cityRepository.GetCityByIdAsync(cityDto.CityId);
            if (existingCity == null)
            {
                throw new AppException($"City with ID {cityDto.CityId} not found");
            }

            cityRepository.UpdateCity(existingCity, cityDto);
            await dataDbContext.SaveChangesAsync();
        }

        private void ValidateCityDto(CityDTO cityDto)
        {
            // Add any validation logic specific to CityDTO
            // You can use ValidationUtils or other validation methods here.
        }
    }
}