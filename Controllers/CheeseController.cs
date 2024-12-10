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
public class CheesesController: Controller
{
    private ShepherdsPiesDbContext _DbContext;
    private IMapper _mapper;
    public CheesesController( ShepherdsPiesDbContext db, IMapper mapper)
    {
        _DbContext = db;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_DbContext.Cheeses.ProjectTo<CheeseDTO>(_mapper.ConfigurationProvider));
    }
    
}