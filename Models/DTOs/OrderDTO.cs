using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Models.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int? DeliveryEmployeeId { get; set; }
    public EmployeeDTO? DeliveryEmployee {get; set;}
    public bool Completed { get; set; } = false;
    public List<PizzaForOrderDTO> Pizzas { get; set; } 
    public decimal Total
    {
        get
        {
            return Pizzas.Aggregate(0m, (total, p) => {
                return total += p.PizzaTotal;
            });
        }
    }

}

