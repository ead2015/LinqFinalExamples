using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSqlExample
{
    [Table(Name="Students")]
    class Student {
        
        [Column(Name="Id",IsDbGenerated=true, IsPrimaryKey=true)]
        public int Id { get; set; }

        [Column (Name="Name")]
        public string Name { get; set; }

        [Column (Name="Semester")]
        public string Semester { get; set; }
    }

    class MyDatabaseLink : DataContext
    {
        public MyDatabaseLink()
            : base(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Shuja\DotNetSamples\F10\Linq\LinqToSqlExample\LinqToSqlExample\App_Data\LinqSampleDb.mdf;Integrated Security=True")
        { 
        
        }

        public Table<Student> Students;
    }
    //*/
    class Program
    {
        static void Main(string[] args)
        {
           
            MyDatabaseLink context = new MyDatabaseLink();
            //retrieval
            var query = from s in context.Students
                        select s;

            Console.WriteLine("SQL query ="+ context.GetCommand(query).CommandText);
            foreach (var i in query)
            {
                Console.WriteLine("student = "+ i.Name);
            }

            //insertion

            Student std = new Student();
            std.Name = "a new Student";
            std.Semester = "8th";
            context.Students.InsertOnSubmit(std);
            context.SubmitChanges();

            Console.WriteLine("------------------------------------");
            foreach (var i in query)
            {
                Console.WriteLine("student = " + i.Name);
            }
            
            //updation

            std = context.Students.First(x => x.Name.Contains("c"));
            Console.WriteLine("std id = "+ std.Id);
            std.Semester = "2nd";

            context.SubmitChanges();


            //deletaion
            std = context.Students.First();
            context.Students.DeleteOnSubmit(std);

            context.SubmitChanges();//*/
        }
    }
}
