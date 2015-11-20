using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ2
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
        public string Product { get; set; }
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
         new Order{ID = 5, CustomerId=5, Product = "Book"},
         new Order{ID = 6, CustomerId=5, Product = "Game"},
         new Order{ID = 7, CustomerId=6, Product = "Computer"},
         // new Order{ID = 7, CustomerId=6, Product = "Computer"}
         new Order{ID = 8, CustomerId=6,Product = "Shirt"}
     };

              //Join on the ID properties.
            
            var query = from c in customers
                         join o in orders on c.ID equals o.CustomerId
                         where c.Name.StartsWith("a")
                         select new { c.Name, o.Product };


             //var query = (from c in customers
             //             from o in orders
             //             where c.ID == o.CustomerId
             //             select new { c.Name, o.Product });
      
            //Syntax Method
             var query2 = customers.Join(orders, c => c.ID, o => o.CustomerId, (c, o) => new { c.Name, o.Product });
           
             // Display joined groups.
             foreach (var group in query)
             {
                 Console.WriteLine("{0} bought {1}", group.Name, group.Product);
             }
         }//*/
    }
}
