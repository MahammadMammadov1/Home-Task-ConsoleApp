using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upcasting_Downcasting.Enum;
using Upcasting_Downcasting.Interface;
using static System.Reflection.Metadata.BlobBuilder;

namespace Upcasting_Downcasting.Models
{
    internal class Department 
    {
        public string Name { get; set; }
        private static int _id;
        public int EmployeeLimit { get; set; }

        public int Id { get; }

        static Department()
        {
            _id = 0;
        }


        public Department(string name, int employeeLimit)
        {
            _id++;
            Id = _id;
            Name = name;
            EmployeeLimit = employeeLimit;

        }

        Employee[] Employees = Array.Empty<Employee>();

        public void AddEmployee(Employee employee)
        {
            if (EmployeeLimit < Employees.Length+1)
            {

                throw new CapacityLimitException("\n\nİŞÇİ LİMİTİ AŞILDI SON DAXIL EDİLƏN İŞÇİ QEYDƏ ALINMADI !!!\n\nBAŞQA EMELİYYAT SEÇİN\n\n");
                
            }
            else
            {
                Array.Resize(ref Employees, Employees.Length + 1);
                Employees[^1] = employee;
            }

        }

        public void AddEmployee(ref Employee[] array, Employee employee)
        {
            Array.Resize(ref array, array.Length + 1);
            array[^1] = employee;
        }

        

        public void RemoveEmployee(int id)
        {
            Employee[] newArr = new Employee[Employees.Length - 1];
            int index = 0;

            for (int i = 0; i < Employees.Length; i++)
            {
                if (Employees[i].Id != id)
                {
                    newArr[index] = Employees[i];
                    index++;
                }
            }
            

            Employees = newArr;
        }


        public Employee GetEmployee(int id)
        {
            
            foreach (Employee employee in Employees)
            {
                if (employee.Id == id)
                {
                    
                    return employee;
                }
            }
            return null;
        }

        public Employee[] GetEmployeesBySalary(double minSalary, double maxSalary)
        {
            Employee[] newArr1 = Array.Empty<Employee>();
            for (int i = 0; i < Employees.Length; i++)
            {
                if (Employees[i].Salary >= minSalary && Employees[i].Salary <= maxSalary)
                {
                    AddEmployee(ref newArr1, Employees[i]);
                }
            }
            return newArr1;
        }

        
        public void ShowAllEmployees()
        {
            foreach (var employee in Employees)
            {
                Console.WriteLine(employee.GetInfo());
                Console.WriteLine("--------------------------------------------------");
            }
        }


        public Employee[] GetEmployeesByPosition(Position position)
        {
            Employee[] newArr2 = Array.Empty<Employee>();
            for (int i = 0; i < Employees.Length; i++)
            {

                if (Employees[i].position == position)
                {
                    Array.Resize(ref newArr2, newArr2.Length + 1);
                    newArr2[newArr2.Length - 1] = Employees[i];
                }
            }
            return newArr2;

        }

        


        public Employee this[int index]
        {
            get 
            { 
                return Employees[index];
            }
            set
            { 
                Employees[index] = value; 
            }
        }
    }
}
