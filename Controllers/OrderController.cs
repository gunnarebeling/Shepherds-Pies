using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShepherdsPies.Data;
using ShepherdsPies.Models.DTOs;
using ShepherdsPies.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

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
    [Authorize]
    public IActionResult Get()
    {
        List<OrderDTO> orders =  _DbContext.Orders.ProjectTo<OrderDTO>(_mapper.ConfigurationProvider).ToList();
        List<SimpleOrderDTO> simpleOrders = orders.Select(o => {
            SimpleOrderDTO simpleOrder = _mapper.Map<SimpleOrderDTO>(o);
            return simpleOrder;
        }).OrderByDescending(a => a.OrderDate).ToList();
        return Ok(simpleOrders);
    }
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult Get(string id)
    {
        OrderDTO order =  _DbContext.Orders.ProjectTo<OrderDTO>(_mapper.ConfigurationProvider).Single(o => o.Id == int.Parse(id));
        return Ok(order);
    }

    [HttpPost]
    [Authorize]
    public IActionResult PostNewOrder([FromBody] OrderForPostDTO order)
    {
        Order NewOrder = _mapper.Map<Order>(order);
        NewOrder.OrderDate = DateTime.Now;
        NewOrder.Pizzas.ForEach(p => {
            List<Topping> newToppings = _DbContext.Toppings
            .Where(t => p.Toppings.Select(tp => tp.Id).Contains(t.Id))
            .ToList();
            p.Toppings = newToppings;
        });
        _DbContext.Orders.Add(NewOrder);
        _DbContext.SaveChanges();
        return Created($"/api/orders/{NewOrder.Id}", NewOrder);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(string id)
    {
        Order order = _DbContext.Orders.SingleOrDefault(o => o.Id == int.Parse(id));
        if (order == null)
        {
            return BadRequest();
        }
        _DbContext.Orders.Remove(order);
        _DbContext.SaveChanges();
        return NoContent();
    }
}