using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples
{
    class ContactInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


        public ContactInfo(string n, string a, string p)
        {
            this.Name = n;
            this.Address = a;
            this.Phone = p;
        }
    }
    class EmailAddress {

        public string Name { get; set; }
        public string Address { get; set; }

        public EmailAddress(string n, string a)
        {
            this.Name = n;
            this.Address = a;
        }

        public override string ToString()
        {
            return "Name = " + this.Name + " Address = " + this.Address;
        }
    }
    class Program
    {
       static void Main(string[] args)
        {
            //data source
            int[] numbers = { 0, 1, 2, -3, -5, 7, 10 };

            //Query
            IEnumerable<int> query = from n in numbers
                                     where n > 3
                                     select n;

            //Execution
            foreach (var x in query)
            {
                Console.WriteLine("output = " + x);
            }

            //change first number
            numbers[0] = 99;

            Console.WriteLine(" Execute Again");
            //Execution
            foreach (var x in query)
            {
                Console.WriteLine("output = " + x);
            }

            //2nd example

            string[] strs = { ".com",
                              ".net",
                            "www.mysite.com",
                            "www.mysite.net"};

            var q = from s in strs
                    where s.Length > 4 && s.EndsWith(".net")
                    select s.Substring(0, 4);
                    //select s;

            Console.WriteLine("------------------------------");
            //Execution
            foreach (var x in q)
            {
                Console.WriteLine("output = " + x);
            }

            //Email Address Array
            EmailAddress[] addrs = {new EmailAddress("A","A@a.com"),
                                   new EmailAddress("B","B@b.com"),
                                   new EmailAddress("C","C@c.com")};

            var q2 = from s in addrs
                     select s.Address;

            Console.WriteLine("------------------------------");
            //Execution
            foreach (var x in q2)
            {
                Console.WriteLine("output = " + x);
            }

            //3rd Example
            ContactInfo[] contacts = { new ContactInfo("A","A@a.com","1"),
                                     new ContactInfo("B","B@a.com","2"),
                                     new ContactInfo("c","C@a.com","3")};

            var q3 = from s in contacts
                     select new EmailAddress(s.Name, s.Address); //here we are creating an object of EmailAddress type 

            Console.WriteLine("------------------------------");
            //Execution
            foreach (var x in q3)
            {
                Console.WriteLine("output = " + x);
            }

            //Anonymous Type Example

            var q4 = from s in contacts
                     select new { s.Name, s.Address };// here we are creating an object of anonymous type

            Console.WriteLine("------------Anonymous Type------------------");
            //Execution
            foreach (var x in q3)
            {
                Console.WriteLine("output = " + x);
            }
        }//*/
    }
}
