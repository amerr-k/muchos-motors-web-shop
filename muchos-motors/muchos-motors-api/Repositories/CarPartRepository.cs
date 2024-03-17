using Microsoft.EntityFrameworkCore;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace muchos_motors_api.EntityFramework.Repositories
{
    public class CarPartRepository
    {
        private readonly DataDbContext dataDbContext;

        public CarPartRepository(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        public IQueryable<CarPart> GetAllCarPartsAscAsync(string searchTerm = "")
        {
            return dataDbContext.CarPart
                .Where(carPart => carPart.IsValid)
                .Where(e => EF.Functions.Like(e.Name, $"%{searchTerm}%"))
                .OrderBy(carPart => carPart.Name);
        }
        public IQueryable<CarPart> GetAllCarPartsAscByFilter(string searchTerm, CarPartFilterDTO carPartFilterDTO)
        {
            var query = from cp in dataDbContext.CarPart
                        where cp.IsValid && EF.Functions.Like(cp.Name, $"%{searchTerm}%")
                        join cpc in dataDbContext.CarPartsCompatibility
                            on cp.CarPartId equals cpc.CarPartId
                        join gcm in dataDbContext.GenericCarModel
                            on cpc.GenericCarModelId equals gcm.GenericCarModelId
                        join cb in dataDbContext.CarBrand
                            on gcm.CarBrandId equals cb.CarBrandId
                        where cb.CarBrandId == carPartFilterDTO.SelectedCarBrandId
                              && 
                              (gcm.GenericCarModelId == carPartFilterDTO.SelectedGenericCarModelId 
                              || carPartFilterDTO.SelectedGenericCarModelId == null)
                        orderby cp.Name
                        select cp;
            return query;
        }

        public async Task<CarPart> GetCarPartByIdAsync(int carPartId)
        {
            return await dataDbContext.CarPart
                .FirstOrDefaultAsync(cp => cp.CarPartId == carPartId && cp.IsValid);
        }

        public void DeleteByObject(CarPart carPart)
        {
            carPart.IsValid = false;
        }

        public async Task<CarPart> CreateCarPartAsync(CarPartDTO carPartDto, CancellationToken cancellationToken = default)
        {
            var carPart = new CarPart
            {
                Code = carPartDto.Code,
                Name = carPartDto.Name,
                SellingPrice = carPartDto.SellingPrice,
                PurchasePrice = carPartDto.PurchasePrice,
                WarehouseCount = carPartDto.WarehouseCount,
                Details = carPartDto.Details,
                ImageUrl = carPartDto.ImageUrl,
                IsValid = true
            };
            await dataDbContext.AddAsync(carPart, cancellationToken);
            return carPart;
        }

        public void UpdateCarPart(CarPart existingCarPart, CarPartDTO carPartDto)
        {
            existingCarPart.Code = carPartDto.Code;
            existingCarPart.Name = carPartDto.Name;
            existingCarPart.SellingPrice = carPartDto.SellingPrice;
            existingCarPart.PurchasePrice = carPartDto.PurchasePrice;
            existingCarPart.Details = carPartDto.Details;
            existingCarPart.ImageUrl = carPartDto.ImageUrl;
        }

        public void UpdateCarPartQuantity(CarPart existingCarPart, int quantity)
        {
            existingCarPart.WarehouseCount += quantity;
        }
    }
}
