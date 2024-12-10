using System.ComponentModel.DataAnnotations;

namespace ShepherdsPies.Models.DTOs;

public class ToppingDTO
{
    public int Id { get; set; }

    public string Type { get; set; }
    
}

public class ToppingForPostDTO
{
    public int ToppingId { get; set; }
}