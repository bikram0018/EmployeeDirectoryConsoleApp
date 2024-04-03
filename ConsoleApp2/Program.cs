using System;
using System.Text.Json;
using project1;
namespace project2
{
    public class Service
    {
        public static void Main(string[] args)
        {

            EmployeeMethods obj = new EmployeeMethods();
            int option;
            Boolean isDone = true;
            while (isDone)
            {
                obj.DisplayOptions();
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        obj.AddEmployeeDetails();
                        break;
                    case 2:
                        obj.EditEmployeeDetails();
                        break;
                    case 3:
                        obj.GetEmployeeIdToShowDetails();
                        break;
                    case 4:
                        foreach (var key in obj.employees.Keys)
                        {
                            obj.ShowEmployeeDetails(obj.employees[key]);
                        }
                        break;
                    case 5:
                        obj.DeleteEmployeeDetails();
                        break;
                    case 6:
                        isDone = false;
                        break;
                }
            }
        }
    }
}