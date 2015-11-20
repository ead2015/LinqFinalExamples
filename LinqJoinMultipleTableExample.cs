using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ3
{
    class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class Order
    {
        public int ID { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
    }
    class Product
    {
        public int ID { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
    }
    class LinqJoinExample
    {
         static void Main()
          {
              // Example customers.
              var customers = new Customer[]
      {
          new Customer{ID = 5, Name = "umair"},
          new Customer{ID = 6, Name = "asad"},
          new Customer{ID = 7, Name = "adil"},
          new Customer{ID = 8, Name = "fahad"}
      };

              // Example orders.
              var orders = new Order[]
      {
          new Order{ID = 5, CustomerId=5, ProductId = 1},
          new Order{ID = 6, CustomerId=5, ProductId = 2},
          new Order{ID = 7, CustomerId=6, ProductId = 1},
          // new Order{ID = 7, CustomerId=6, ProductId = 2}
          new Order{ID = 8, CustomerId=6,ProductId = 3}
      };
              // Example products.
              var products = new Product[]
      {
          new Product{ID = 1, Price=5, Name = "Computer"},
          new Product{ID = 2, Price=5, Name = "Mobile"},
          new Product{ID =3, Price=5, Name = "Laptop"}
	    
      };

              // Join on the ID properties.
              //var query = from c in customers
              //            join o in orders on c.ID equals o.CustomerId 
              //            join p in products on o.ProductId equals p.ID
              //            select new { Customer = c.Name, Product =p.Name };


              //var query = (from c in customers
              //             from o in orders
              //             from p in products
              //             where c.ID == o.CustomerId &&
              //                   o.ProductId== p.ID
              //             select new { Customer = c.Name, Product =p.Name });
      
             //Method Syntax 
              var query = customers.Join(orders, c => c.ID, o => o.CustomerId, (c, o) => new { c.Name, o.ProductId })
                                   .Join(products, co => co.ProductId, p => p.ID, (co, p) => new { Customer = co.Name, Product=p.Name});
           
              // Display joined groups.
              foreach (var group in query)
              {
                  Console.WriteLine("{0} bought {1}", group.Customer, group.Product);
              }
          }//*/
    }
}
