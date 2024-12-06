using System.ComponentModel.DataAnnotations;

namespace ShepherdsPies.Models.DTOs;

public class SizeDTO
{
    public int Id { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
}