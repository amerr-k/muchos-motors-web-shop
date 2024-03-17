using Microsoft.EntityFrameworkCore;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace muchos_motors_api.EntityFramework.Repositories
{
    public class GenericCarModelRepository
    {
        private readonly DataDbContext dataDbContext;

        public GenericCarModelRepository(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        public async Task<List<GenericCarModel>> GetAllGenericCarModelsAscAsync()
        {
            return await dataDbContext.GenericCarModel
                .Where(genericCarModel => genericCarModel.IsValid)
                .OrderBy(genericCarModel => genericCarModel.ModelName)
                .ToListAsync();
        }

        public async Task<GenericCarModel> GetGenericCarModelByIdAsync(int genericCarModelId)
        {
            return await dataDbContext.GenericCarModel
                .FirstOrDefaultAsync(gcm => gcm.GenericCarModelId == genericCarModelId && gcm.IsValid);
        }

        public void DeleteByObject(GenericCarModel genericCarModel)
        {
            genericCarModel.IsValid = false;
        }

        public async Task<GenericCarModel> CreateGenericCarModelAsync(GenericCarModelDTO genericCarModelDto)
        {
            var genericCarModel = new GenericCarModel
            {
                GenericCarModelId = genericCarModelDto.GenericCarModelId,
                ModelName = genericCarModelDto.ModelName,
                GenerationName = genericCarModelDto.GenerationName,
                CarBrandId = genericCarModelDto.CarBrandId,
                ProductionStartYear = genericCarModelDto.ProductionStartYear,
                ProductionEndYear = genericCarModelDto.ProductionEndYear,
                IsValid = true
            };
            await dataDbContext.AddAsync(genericCarModel);
            return genericCarModel;
        }

        public void UpdateGenericCarModel(GenericCarModel existingGenericCarModel, GenericCarModelDTO genericCarModelDto)
        {
            existingGenericCarModel.GenericCarModelId = genericCarModelDto.GenericCarModelId;
            existingGenericCarModel.ModelName = genericCarModelDto.ModelName;
            existingGenericCarModel.GenerationName = genericCarModelDto.GenerationName;
            existingGenericCarModel.CarBrandId = genericCarModelDto.CarBrandId;
            existingGenericCarModel.ProductionStartYear = genericCarModelDto.ProductionStartYear;
            existingGenericCarModel.ProductionEndYear = genericCarModelDto.ProductionEndYear;
        }
    }
}
