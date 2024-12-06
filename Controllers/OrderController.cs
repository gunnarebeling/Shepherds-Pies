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
public class OrderController: Controller
{
    private ShepherdsPiesDbContext _DbContext;
    private IMapper _mapper;
    public OrderController( ShepherdsPiesDbContext db, IMapper mapper)
    {
        _DbContext = db;
        _mapper = mapper;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        List<OrderDTO> orders =  _DbContext.Orders.ProjectTo<OrderDTO>(_mapper.ConfigurationProvider).ToList();
        return Ok(orders);
    }
}