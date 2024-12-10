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
        CreateMap<Cheese, CheeseDTO>();
        CreateMap<Sauce, SauceDTO>();
        CreateMap<Topping, ToppingDTO>();
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<Employee, SimpleEmployeeDTO>();
        CreateMap<OrderForPostDTO, Order>();
        CreateMap<PizzaForPostDTO, Pizza>();
        CreateMap<ToppingForPostDTO, Topping>();
        CreateMap<ToppingDTO, Topping>();

        
        

    }
        
    
}