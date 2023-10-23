using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcasting_Downcasting.Enum;
using Upcasting_Downcasting.Interface;

namespace Upcasting_Downcasting.Models
{
    internal class Employee : IPerson
    {

        private static int _id;
        public Position position;

        public int Id { get; }


        static Employee()
        { 
            _id = 0;
        }

        public Employee(string? name, int age, int salary, Position position)
        {
            _id++;
            Id = _id;
            Name = name;
            Age = age;
            Salary = salary;
            this.position = position;
        }

        public string Name { get; set; }
        private int _age;
        public int Age 
        {
            get
            {
                return _age;
            }
            set
            {
                if( value > 0 && value<150 ) 
                { 
                    _age = value;
                }
            } 
        }
        public int Salary { get; set; }
        public string Position { get; set; }



        public string GetInfo()
        {
            return $"ID: {Id} - Name: {Name} - Age: {Age} - Salary: {Salary} - Position: {position}";
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine($"Position: {Position}");
        }

        public override string ToString()
        {
            return GetInfo();
        }
    }
}
