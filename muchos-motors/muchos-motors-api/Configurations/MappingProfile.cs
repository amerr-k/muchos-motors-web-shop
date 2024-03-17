using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using muchos_motors_api.DTOModels;
using muchos_motors_api.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderDTO>();
        CreateMap<OrderItem, OrderItemDTO>();
        CreateMap<CarPart, CarPartDTO>();
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<CarBrand, CarBrandDTO>();
        CreateMap<GenericCarModel, GenericCarModelDTO>();
        CreateMap<City, CityDTO>();
        CreateMap<Customer, CustomerDTO>();
        CreateMap<InventoryLog, InventoryLogDTO>();
        CreateMap<InventoryCarPartLog, InventoryCarPartLogDTO>();
    }
}