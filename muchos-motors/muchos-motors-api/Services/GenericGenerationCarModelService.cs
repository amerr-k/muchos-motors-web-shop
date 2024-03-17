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
    public class GenericCarModelService
    {
        private readonly DataDbContext dataDbContext;
        private readonly GenericCarModelRepository genericCarModelRepository;
        private readonly Mapper mapper;

        public GenericCarModelService(DataDbContext dataDbContext, GenericCarModelRepository genericCarModelRepository, Mapper mapper)
        {
            this.dataDbContext = dataDbContext;
            this.genericCarModelRepository = genericCarModelRepository;
            this.mapper = mapper;
        }

        public async Task<List<GenericCarModelDTO>> GetAllGenericCarModelsAsync()
        {
            var genericCarModelList = await genericCarModelRepository.GetAllGenericCarModelsAscAsync();
            return mapper.Map<List<GenericCarModelDTO>>(genericCarModelList);
        }

        public async Task<GenericCarModelDTO> GetGenericCarModelByIdAsync(int genericCarModelId)
        {
            var genericCarModel = await genericCarModelRepository.GetGenericCarModelByIdAsync(genericCarModelId);
            if (genericCarModel == null)
            {
                throw new AppException($"GenericCarModel with ID {genericCarModelId} not found", (int)HttpStatusCode.NotFound);
            }
            return mapper.Map<GenericCarModelDTO>(genericCarModel);
        }

        public async Task DeleteGenericCarModelAsync(int genericCarModelId)
        {
            var genericCarModel = await genericCarModelRepository.GetGenericCarModelByIdAsync(genericCarModelId);
            if (genericCarModel == null)
            {
                throw new AppException($"GenericCarModel with ID {genericCarModelId} not found");
            }
            genericCarModelRepository.DeleteByObject(genericCarModel);
            await dataDbContext.SaveChangesAsync();
        }

        public async Task<GenericCarModel> CreateGenericCarModelAsync(GenericCarModelDTO genericCarModelDto)
        {
            ValidateGenericCarModelDto(genericCarModelDto);

            var createdGenericCarModel = await genericCarModelRepository.CreateGenericCarModelAsync(genericCarModelDto);
            await dataDbContext.SaveChangesAsync();
            return createdGenericCarModel;
        }

        public async Task UpdateGenericCarModelAsync(GenericCarModelDTO genericCarModelDto)
        {
            ValidateGenericCarModelDto(genericCarModelDto);

            var existingGenericCarModel = await genericCarModelRepository.GetGenericCarModelByIdAsync(genericCarModelDto.GenericCarModelId);
            if (existingGenericCarModel == null)
            {
                throw new AppException($"GenericCarModel with ID {genericCarModelDto.GenericCarModelId} not found");
            }

            genericCarModelRepository.UpdateGenericCarModel(existingGenericCarModel, genericCarModelDto);
            await dataDbContext.SaveChangesAsync();
        }

        private void ValidateGenericCarModelDto(GenericCarModelDTO genericCarModelDto)
        {
            // Add any validation logic specific to GenericCarModelDTO
            // You can use ValidationUtils or other validation methods here.
        }
    }
}