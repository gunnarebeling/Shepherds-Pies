using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShepherdsPies.Data;
using ShepherdsPies.Models.DTOs;
using ShepherdsPies.Models;

namespace ShepherdsPies.Controllers;

[Controller]
[Route("api/[controller]")]
public class OrdersController: Controller
{
    private ShepherdsPiesDbContext _DbContext;
    private IMapper _mapper;
    public OrdersController( ShepherdsPiesDbContext db, IMapper mapper)
    {
        _DbContext = db;
        _mapper = mapper;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        List<OrderDTO> orders =  _DbContext.Orders.ProjectTo<OrderDTO>(_mapper.ConfigurationProvider).ToList();
        List<SimpleOrderDTO> simpleOrders = orders.Select(o => {
            SimpleOrderDTO simpleOrder = _mapper.Map<SimpleOrderDTO>(o);
            return simpleOrder;
        }).OrderByDescending(a => a.OrderDate).ToList();
        return Ok(simpleOrders);
    }
}