using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaoriSouvenirShopping.Models;

namespace MaoriSouvenirShopping.Data
{
    public class DbInitializer
    {
        public static void Initialize(WebShopContext context)
        {
            context.Database.EnsureCreated();
            // Look for any Customer.
            if (context.OrderItems.Any())
            {
                return;   // DB has been seeded
            }
            //var customers = new Customer[]
            //{
            //     new Customer{LastName="John", FirstName="Tom", PhoneNumber="0211231234", Email="TJohn@gmail.com", Address="139 Carrington RD, Auckland"},
            //};
            //foreach (Customer c in customers)
            //{
            //    context.Customers.Add(c);
            //}
            //context.SaveChanges();
            //var categories = new Category[]
            //{
            //     new Category{CategoryName="Jewel", Description="Treasure"},
            //};
            //foreach (Category c in categories)
            //{
            //    context.Categories.Add(c);
            //}
            //context.SaveChanges();
            //var suppliers = new Supplier[]
            //{
            //    new Supplier{LastName="Ben", FirstName="Jerry", PhoneNumber="0227777777", Email="BJerry@gmail.com", Address="125 Carrington RD, Auckland"},
            //};
            //foreach (Supplier s in suppliers)
            //{
            //    context.Suppliers.Add(s);
            //}
            //context.SaveChanges();
            //var souvenires = new Souvenir[]
            //{
            //     new Souvenir{SouvenirName="Jade Nicklace",
            //         Price =1000.00, PhotoPath="foo", Description="Beautiful",
            //         CategoryID =1, SupplierID=1},
            //};
            //foreach (Souvenir s in souvenires)
            //{
            //    context.Souvenirs.Add(s);
            //}
            //context.SaveChanges();
            //var orders = new Order[]
            //{
            //     new Order{OrderDate=DateTime.Parse("2018-09-01"),
            //         Status=Status.Ordered, CustomerID=3, TotalCost=1000.00},
            //};
            //foreach (Order o in orders)
            //{
            //    context.Orders.Add(o);
            //}
            //context.SaveChanges();
            //var orderItems = new OrderItem[]
            //{
            //     new OrderItem{OrderID=5, SouvenirID=9, ItemAmount=1}
            // };
            //foreach (OrderItem o in orderItems)
            //{
            //    context.OrderItems.Add(o);
            //}
            //context.SaveChanges();

        }
    }
}
