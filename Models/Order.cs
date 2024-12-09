using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShepherdsPies.Models;

public class Order
{
    public int Id { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    public int OrderEmployeeId { get; set; }
    [ForeignKey("OrderEmployeeId")]
    public Employee OrderEmployee { get; set; }
    public int? DeliveryEmployeeId { get; set; }
    [ForeignKey("DeliveryEmployeeId")]
    public Employee? DeliveryEmployee {get; set;}
    public bool Completed { get; set; } = false;
    public List<Pizza> Pizzas { get; set; }

    public decimal Tip { get; set; }
}