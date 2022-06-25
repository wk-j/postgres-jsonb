// See https://aka.ms/new-console-template for more information


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyApp;
using MyApp.Models;

var conn = "Host=localhost;User Id=MyUser;Password=MyPassword;Database=MyDb";
var logging = LoggerFactory.Create(builder => builder.AddConsole());
var builder = new DbContextOptionsBuilder<MyDbContext>()
    .UseLoggerFactory(logging)
    .UseNpgsql(conn);

var db = new MyDbContext(builder.Options);

// Insert();
Query4();

void Query4()
{
    // ?
    var order = new Order { Price = 200, ShippingAddress = "A 002" };
    var x = db.SomeEntities.Where(x => EF.Functions.JsonContains(x.Customer.Orders, "{}")).ToList();
    foreach (var item in x)
    {
        Console.WriteLine("{0}", item.Customer.Name);
        foreach (var o in item.Customer.Orders)
        {
            Console.WriteLine("Price: {0}", o.Price);
        }
    }
}


void Query3()
{
    var x = db.SomeEntities.Where(x => x.Customer.Name == "wk").ToList();
    foreach (var item in x)
    {
        Console.WriteLine("{0} {1}", item.Customer.Name, item.Customer.Age);
    }
}

void Query1()
{
    // could not be translated
    // var x = db.SomeEntities.Where(x => x.Customer.Orders.Any(x => x.ShippingAddress == "A 001"));
}

void Query2()
{
    // ok
    var x = db.SomeEntities.Where(x => EF.Functions.JsonContains(x.Customer, @"{""Name"": ""Joe"", ""Age"": 25}"));
    foreach (var item in x)
    {
        Console.WriteLine("{0} ", item.Id);
    }

}

void Insert()
{
    db.SomeEntities.Add(new MyApp.SomeEntity
    {
        Customer = new MyApp.Customer
        {
            Name = "wk",
            Age = 20,
            Orders = new List<Order> {
                new Order {
                    Price = 100,
                    ShippingAddress = "A 001"
                },
                new Order {
                    Price = 200,
                    ShippingAddress = "A 002"
                }
            }.ToArray()
        }
    });
    db.SaveChanges();
}
