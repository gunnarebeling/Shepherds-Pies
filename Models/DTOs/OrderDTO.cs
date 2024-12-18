using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Models.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int? DeliveryEmployeeId { get; set; }
    public int OrderEmployeeId { get; set; }
    public SimpleEmployeeDTO OrderEmployee { get; set; }
    public SimpleEmployeeDTO? DeliveryEmployee {get; set;}
    public bool Completed { get; set; } = false;
    public List<PizzaForOrderDTO> Pizzas { get; set; }

    public decimal Tip { get; set; }
    private decimal deliveryCharge = 5m; 
    public decimal Total
    {
        get
        {
            
            decimal preTotal =  Pizzas.Aggregate(0m, (total, p) => {
                 total += p.PizzaTotal;
                 return total;
            });
            if(DeliveryEmployeeId != null )
            {
                preTotal += deliveryCharge;
            }
            return preTotal + Tip;
        }
    }

}

public class SimpleOrderDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int? DeliveryEmployeeId { get; set; }
    public SimpleEmployeeDTO? DeliveryEmployee {get; set;}
    public bool Completed { get; set; } = false;
    public decimal Total {get; set;}
    
}
public class OrderForPostDTO
{
    public int? DeliveryEmployeeId { get; set; }
    public int OrderEmployeeId { get; set; }
   public decimal Tip { get; set; }
   public List<PizzaForPostDTO> Pizzas { get; set; }

}
