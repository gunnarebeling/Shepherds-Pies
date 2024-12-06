using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace ShepherdsPies.Models;

public class Pizza
{
    
    public int Id { get; set; }
    public int SizeId { get; set; }
    public Size Size { get; set; }
    public int CheeseId { get; set; }
    public Cheese Cheese { get; set; }
    public int SauceId { get; set; }
    public Sauce Sauce { get; set; }
    public List<Topping> Toppings { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
}