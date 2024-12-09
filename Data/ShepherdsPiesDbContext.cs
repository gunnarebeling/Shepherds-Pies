using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ShepherdsPies.Models;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Data;
public class ShepherdsPiesDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Cheese> Cheeses { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Sauce> Sauces { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Order> Orders { get; set; }

    public ShepherdsPiesDbContext(DbContextOptions<ShepherdsPiesDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            
        });
        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "a4b9c99e-87ab-4c5a-9d53-1e3f5248a1b0", // Unique GUID for this user
            UserName = "JohnDoe",
            Email = "johndoe@example.com",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["JohnDoePassword"]) // Store password securely
        });

        // Seeding the Employee entity for the non-admin user
        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            Id = 2, // Unique Employee ID
            IdentityUserId = "a4b9c99e-87ab-4c5a-9d53-1e3f5248a1b0", // Links to the IdentityUser ID
            FirstName = "John",
            LastName = "Doe"
        });

        modelBuilder.Entity<Cheese>().HasData(new Cheese[]
        {
            new Cheese
            {
                Id = 1,
                Type = "Buffalo Mozzarella"
                
            },
            new Cheese
            {
                Id = 2,
                Type = "Four Cheese"
                
            },
            new Cheese
            {
                Id = 3,
                Type = "Vegan"
                
            },
            new Cheese
            {
                Id = 4,
                Type = "Cheeseless"
                
            },
        });

        modelBuilder.Entity<Size>().HasData(new Size[]
        {
            new Size
            {
                Id = 1,
                Type = "small(10\")",
                Price = 10m
                
            },
            new Size
            {
                Id = 2,
                Type = "medium(14\")",
                Price = 12m
                
            },
            new Size
            {
                Id = 3,
                Type = "large(18\")",
                Price = 15m
                
            }
        });

        modelBuilder.Entity<Sauce>().HasData(new Sauce[]
        {
            new Sauce
            {
                Id = 1,
                Type = "Marinara"
                
            },
            new Sauce
            {
                Id = 2,
                Type = "Arrabbiata"
                
            },
            new Sauce
            {
                Id = 3,
                Type = "Garlic White"
                
            },
            new Sauce
            {
                Id = 4,
                Type = "None(sauceless pizza)"
                
            }
        });

        modelBuilder.Entity<Topping>().HasData(new Topping[]
        {
            new Topping
            {
                Id = 1,
                Type = "Sausage"
                
            },
            new Topping
            {
                Id = 2,
                Type = "pepperoni"
                
            },
            new Topping
            {
                Id = 3,
                Type = "mushroom"
                
            },
            new Topping
            {
                Id = 4,
                Type = "onion"
                
            },
            new Topping
            {
                Id = 5,
                Type = "green pepper"
                
            },
            new Topping
            {
                Id = 6,
                Type = "black olive"
                
            },
            new Topping
            {
                Id = 7,
                Type = "basil"
                
            },
            new Topping
            {
                Id = 8,
                Type = "extra cheese"
                
            }
        });

        modelBuilder.Entity<Order>().HasData(new Order[]
        {
            new Order
            {
                Id = 1,
                OrderDate = DateTime.Now,
                OrderEmployeeId = 1,
                Tip = 10m   
            },
            new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                OrderEmployeeId = 2,
                DeliveryEmployeeId = 1,
                Tip = 5m   
            },
            new Order
            {
                Id = 3,
                OrderDate = DateTime.Now,
                OrderEmployeeId = 1,
                Tip = 7m 
            }
        });
        modelBuilder.Entity<Pizza>().HasData(new Pizza[]
        {
            new Pizza
            {
                Id = 1,
                SizeId = 2,
                CheeseId = 1,
                SauceId = 2,
                OrderId = 1   
            },
            new Pizza
            {
                Id = 2,
                SizeId = 3,
                CheeseId = 2,
                SauceId = 1,
                OrderId = 1   
            },
            new Pizza
            {
                Id = 3,
                SizeId = 1,
                CheeseId = 1,
                SauceId = 1,
                OrderId = 2   
            },
            new Pizza
            {
                Id = 4,
                SizeId = 2,
                CheeseId = 1,
                SauceId = 2,
                OrderId = 3   
            }
        });
        

        modelBuilder.Entity<Pizza>()
            .HasMany(p => p.Toppings)
            .WithMany(t => t.Pizzas)
            .UsingEntity(j => j.HasData(
                new { PizzasId = 1, ToppingsId = 1 },
                new { PizzasId = 1, ToppingsId = 2 },
                new { PizzasId = 1, ToppingsId = 3 },
                new { PizzasId = 2, ToppingsId = 4 },
                new { PizzasId = 2, ToppingsId = 3 },
                new { PizzasId = 2, ToppingsId = 1 }
            ));

        
    }
}