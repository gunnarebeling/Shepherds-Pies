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
public class PizzasController: Controller
{
    private ShepherdsPiesDbContext _DbContext;
    private IMapper _mapper;
    public PizzasController( ShepherdsPiesDbContext db, IMapper mapper)
    {
        _DbContext = db;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_DbContext.Pizzas.ProjectTo<PizzaForOrderDTO>(_mapper.ConfigurationProvider));
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(string id)
    {
        Pizza pizza = _DbContext.Pizzas.SingleOrDefault(p => p.Id == int.Parse(id));
        if (pizza == null)
        {
            return BadRequest();
        }
        _DbContext.Pizzas.Remove(pizza);
        _DbContext.SaveChanges();
        return NoContent();
    }
    
    
}