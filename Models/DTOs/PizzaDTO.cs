using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Models.DTOs;

public class PizzaForOrderDTO
{
    private decimal _toppingPrice = 0.5m;
    public int Id { get; set; }
    public int SizeId { get; set; }
    public SizeDTO Size { get; set; }
    public int CheeseId { get; set; }
    public CheeseDTO Cheese { get; set; }
    public int SauceId { get; set; }
    public SauceDTO Sauce { get; set; }
    public List<ToppingDTO> Toppings { get; set; }
    public decimal PizzaTotal 
    {
        get
        {
            
            return Toppings.Any() ?  Size.Price + Toppings.Count * _toppingPrice : Size.Price;
        }
    }
}

public class PizzaForPostDTO
{
    public int SizeId { get; set; }
    public int CheeseId { get; set; }
    public int SauceId { get; set; }
    public List<ToppingDTO> Toppings { get; set; }

}   

