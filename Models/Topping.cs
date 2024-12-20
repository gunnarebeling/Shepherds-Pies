using System.ComponentModel.DataAnnotations;

namespace ShepherdsPies.Models;

public class Topping
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    public List<Pizza> Pizzas { get; set; }
}