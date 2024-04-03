using System;
using System.Collections.Generic;
    public class Employee
    {
        public int empNo;
        public string empName;
        public string empMail;
        public string location;
        public string department;
        public string role;
        public Employee()
        {
            Console.Write("Enter Employee Number : ");
            this.empNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name : ");
            this.empName = Console.ReadLine();
            Console.Write("Enter Employee Mail : ");
            this.empMail = Console.ReadLine();
            Console.Write("Enter location : ");
            this.location = Console.ReadLine();
            Console.Write("Enter Department : ");
            this.department = Console.ReadLine();
            Console.Write("Enter Role : ");
            this.role = Console.ReadLine();
        }
    }
     class EmployeeMethods
    {
        public Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
        public void DisplayOptions()
        {
            Console.WriteLine(@"Select a option\n
             1. Add Employee Details\n
             2. Update Employee Details\n
             3. Get Employee Details\n
             4. Get All Employees Details\n
             5. Delete Employee Details\n
             6. Exit");
        }
        public void AddEmployeeDetails()
        {
            Employee employee = new Employee();
            if (!this.employees.ContainsKey(employee.empNo))
            {
                this.employees.Add(employee.empNo, employee);
                Console.WriteLine("Employee Added Successfully! ");
            }
            else
            {
                Console.WriteLine("Employee Number already exists!!");
            }
        }
        public void EditEmployeeDetails()
        {
            Console.Write("Enter Employee number:");
            int empNo = Convert.ToInt32(Console.ReadLine());
            if (this.employees.ContainsKey(empNo))
            {
                Employee employee = this.employees[empNo];
                int option;
                bool done = true;
                while (done)
                {
                    Console.WriteLine(@"Select to edit employee\n
                        1.Employee Name\n
                        2.Employee Mail\n
                        3.Location\n
                        4.Department\n
                        5.Role\n
                        6.Exit\n
                    ");
                    option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.Write("Enter Employee Name : ");
                            employee.empName = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("Enter Employee Mail : ");
                            employee.empMail = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Enter Location : ");
                            employee.location = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("Enter Department : ");
                            employee.department = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("Enter Role : ");
                            employee.role = Console.ReadLine();
                            break;
                        case 6:
                            done = false;
                            break;
                    }
                }
                Console.WriteLine("Employee Detials Updated Successfully! ");
            }
            else
            {
                Console.WriteLine("Invalid Employee Number");
            }
        }
        public void GetEmployeeIdToShowDetails()
        {
            Console.Write("Enter Employee number:");
            int empNo = Convert.ToInt32(Console.ReadLine());
            if (this.employees.ContainsKey(empNo))
            {
                this.ShowEmployeeDetails(this.employees[empNo]);
            }
            else
            {
                Console.WriteLine("InValid Employee Number");
            }
        }
         public void ShowEmployeeDetails(Employee employee)
        {
            Console.WriteLine("{0,-15} | {1,-8} | {2,-25} | {3,-15} | {4,-15} | {5,-15}", employee.empName, employee.empNo, employee.empMail, employee.location, employee.department, employee.role);
        }
         public void DeleteEmployeeDetails()
        {
            Console.Write("Enter Employee Number : ");
            int empNo = Convert.ToInt32(Console.ReadLine());
            if (this.employees.ContainsKey(empNo))
            {
                this.employees.Remove(empNo);
                Console.WriteLine("Employee Details removed Successfuylly! ");
            }
            else
            {
                Console.WriteLine("Enter Valid Employee Number");
            }
        }
        public static void Main(string[] args)
        {
        }
    }