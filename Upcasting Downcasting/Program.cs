using System.Diagnostics;
using Upcasting_Downcasting.Enum;
using Upcasting_Downcasting.Models;

namespace Upcasting_Downcasting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department("MM",3);
            

            int choice;


            do
            {
                Console.WriteLine("Choose operation");
                Console.WriteLine("===========================================");
                Console.WriteLine("1. Employee elave et" +
                    "\n2. İşci axtar" +
                    "\n3. Bütün işçilere bax" +
                    "\n4. Maaş aralığına göre işçileri axtarış et" +
                    "\n5. Departamentə göre işçileri axtarış et"+
                    "\n6. Positiona görə işçiləri axtarış et" +
                    "\n7. İşçini qov" +
                    "\n0. Proqrami bitir");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        try 
                        {
                            department.AddEmployee(CreateEmployee());
                        }
                        catch (CapacityLimitException ex) 
                        { 
                            Console.WriteLine(ex.Message); 
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the Id: ");
                        int id = int.Parse(Console.ReadLine());
                        Employee foundEmployee = department.GetEmployee(id);
                        if (foundEmployee != null)
                        {
                            Console.WriteLine(foundEmployee);
                        }
                        else
                        {
                            Console.WriteLine("Employee not found!");
                        }
                        break;

                        
                    case 3:
                        department.ShowAllEmployees();

                        break;
                    case 4:
                        Console.WriteLine("Enter the minimum Salary : ");
                        int minS = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the mmaximum Salary : ");
                        int maxS = int.Parse(Console.ReadLine());
                        foreach (var item in department.GetEmployeesBySalary(minS, maxS))
                        {
                            Console.WriteLine(item.GetInfo());
                        }
                        break;
                    case 5:
                        Console.WriteLine();
                        break;
                    
                    case 6:
                        Console.WriteLine("Select position:");
                        Console.WriteLine("1 - Boss");
                        Console.WriteLine("2 - Engineer");
                        Console.WriteLine("3 - HR");
                        int positionChoice;
                        do
                        {
                            Console.WriteLine("You can only input 1,2,3");
                            positionChoice = int.Parse(Console.ReadLine());

                        } while (!(positionChoice >= 1 && positionChoice <= 3));
                        Position selectedPosition;
                        switch (positionChoice)
                        {
                            case 1:
                                selectedPosition = Position.Boss;
                                break;
                            case 2:
                                selectedPosition = Position.Engineer;
                                break;
                            case 3:
                                selectedPosition = Position.HR;
                                break;
                            default:
                                selectedPosition = Position.Boss;
                                continue;
                        }
                        Employee[] employeesByPosition = department.GetEmployeesByPosition(selectedPosition);
                        
                        foreach (var employee in employeesByPosition)
                        {
                            Console.WriteLine(employee.GetInfo());
                        }
                        break;
                    case 7:
                        Console.WriteLine("Enter Id :");
                        int removeId = int.Parse(Console.ReadLine());
                        department.RemoveEmployee(removeId);

                        break;



                }


            } while (choice !=0);
        }


        public static Employee CreateEmployee()
        {
            Employee employee = null;

            Console.Write("Enter employee name: ");
            string name = Console.ReadLine();

            Console.Write("Enter employee Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter employee Salary: ");
            int salary = int.Parse(Console.ReadLine());

            Console.WriteLine("Select employee position:");
            Console.WriteLine("1 - Boss");
            Console.WriteLine("2 - Engineer");
            Console.WriteLine("3 - HR");
            int positionChoice;
            do
            {
                Console.WriteLine("You can only input 1,2,3");
                positionChoice = int.Parse(Console.ReadLine());
                
            } while (!(positionChoice >=1 && positionChoice<=3));
            Position position;
            switch (positionChoice)
            {
                case 1:
                    position = Position.Boss;
                    break;
                case 2:
                    position = Position.Engineer;
                    break;
                case 3:
                    position = Position.HR;
                    break;
                default:
                    position = Position.Boss; 
                    break;
            }

            employee = new Employee(name, age, salary, position);
            return employee;
            
        }
    }
}