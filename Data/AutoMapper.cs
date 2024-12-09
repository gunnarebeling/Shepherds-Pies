using AutoMapper;
using ShepherdsPies.Models;
using ShepherdsPies.Models.DTOs;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {

        CreateMap<Order, OrderDTO>();
        CreateMap<OrderDTO, SimpleOrderDTO>();
        CreateMap<Pizza, PizzaForOrderDTO>();
        CreateMap<Size, SizeDTO>();
        CreateMap<Topping, ToppingDTO>();
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<Employee, SimpleEmployeeDTO>();
        
        

    }
        
    
}