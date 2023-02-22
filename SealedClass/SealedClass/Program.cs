using System;
using static System.Console;

namespace SealedClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee= new Employee();
            employee.Id = 2;
            employee.FirstName = "Garen";
            employee.LastName = "Crownguard";
            Executive executive = new Executive(1,"Luxanna", "Crownguard", "CEO", 1000000);
            executive.Pay();
            WriteLine();
            WriteLine("Employee Directory");
            WriteLine();
            executive.Display();
            WriteLine();
            employee.Display();
        }
    }
    interface IEmployee
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
        public double Pay();
    }
    class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }
        public virtual void Display()
        {
            WriteLine($"Id: {Id}");
            WriteLine($"Name: {Fullname()}");

        }

    }
    sealed class Executive : Employee
    {
        public string Title { get; set; }
        public double Salary { get; set; }

        public Executive()
        {
            Id= 0;
            FirstName= string.Empty;
            LastName= string.Empty;
            Title = string.Empty;
            Salary = 0;

        }
        public Executive(int id, string firstName, string lastName, string title, int salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            Salary = salary;
        }

        public override double Pay()
        {
            WriteLine($"What is the yearly pay for {Title} {FirstName} {LastName}");
            Salary= double.Parse(Console.ReadLine());
            return Salary;
        }
        public override void Display()
        {
            WriteLine($"Id: {Id}");
            WriteLine($"Name: {Fullname()}");
            WriteLine($"Title {Title}");
            WriteLine($"Salary: {Salary.ToString("C2")}");
        }
    }
}