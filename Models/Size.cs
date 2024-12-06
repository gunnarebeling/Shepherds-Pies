using System.ComponentModel.DataAnnotations;

namespace ShepherdsPies.Models;

public class Size
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    public decimal Price { get; set; }
}