using System;
using System.Data;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Interfaces;
using EmployeeDirectory.Models.Constants;

namespace EmployeeDirectory.Services.EmployeeManagement
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IRepository<Employee> _repository;
        private readonly EmployeeInputHandler _inputHandler;
        public EmployeeServices(IRepository<Employee> EmpRepoService, EmployeeInputHandler InputHandler) { 
            _repository = EmpRepoService;
            _inputHandler = InputHandler;
        }
        public void AddEmployeeDetails()
        {
            List<Employee> Employees = _repository.Get();
            Employee employee = _inputHandler.ReadEmployeeDetails();
            Employees.Add(employee);
            _repository.Store(Employees);
            Console.WriteLine("Employee Added Successfully! ");
        }
        public void EditEmployeeDetails()
        {
            Console.Write(Constants.EnterEmpNo);
            string empNo = Console.ReadLine();
            List<Employee> Employees = _repository.Get();
            var employeeList = (from employee in Employees where employee.EmpNo == empNo select employee).ToList();
            if (employeeList.Count == 1)
            {
                Employee employee = employeeList[0];
                int option;
                bool isProvidingService = true;
                while (isProvidingService)
                {
                    EmployeeServices.EmployeeEditDispalyOptions();
                    int.TryParse(Console.ReadLine(), out option);
                    switch (option)
                    {
                        case 1:
                            employee.FirstName = _inputHandler.EmployeeFirstNameInput();
                            employee.LastName = _inputHandler.EmployeeLastNameInput();
                            break;
                        case 2:
                            employee.DateOfBirth = _inputHandler.EmployeeDateofBirthInput();
                            break;
                        case 3:
                            employee.EmpMail = _inputHandler.EmployeeMailInput();
                            break;
                        case 4:
                            employee.MobileNumber = _inputHandler.EmployeeMobileNumberInput();
                            break;
                        case 5:
                            employee.JoiningDate = _inputHandler.EmployeeJoinDateInput();
                            break;
                        case 6:
                            employee.RoleId = _inputHandler.EmployeeRoleIdInput();
                            Role RoleValues = _inputHandler.GetRoleValues(employee.RoleId);
                            employee.JobTitle = RoleValues.RoleName;
                            employee.Location = RoleValues.Location;
                            employee.Department = RoleValues.Department;
                            break;
                        case 7:
                            employee.Location = _inputHandler.EmployeeLocationInput();
                            employee.RoleId = _inputHandler.GetRoleId(employee.Location, employee.JobTitle, employee.Department);
                            break;
                        case 8:
                            employee.JobTitle = _inputHandler.EmployeeJobTitleInput(employee.Location);
                            employee.RoleId = _inputHandler.GetRoleId(employee.Location, employee.JobTitle, employee.Department);
                            break;
                        case 9:
                            employee.Department = _inputHandler.EmployeeDepartmentInput(employee.Location,employee.JobTitle);
                            employee.RoleId = _inputHandler.GetRoleId(employee.Location, employee.JobTitle, employee.Department);
                            break;
                        case 10:
                            employee.Manager = _inputHandler.EmployeeManagerIdInput();
                            break;
                        case 11:
                            employee.Project = _inputHandler.EmployeeProjectNameInput();
                            break;
                        case 12:
                            isProvidingService = false;
                            break;
                    }
                }
                _repository.Store(Employees);
                Console.WriteLine("Employee Detials Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Employee Number!!");
            }
        }
        public static void EmployeeDisplayOptions()
        {
            Console.WriteLine(Constants.EmpDisplayMenu);
        }
        public static void EmployeeEditDispalyOptions()
        {
            Console.WriteLine(Constants.EmpEditDisplayMenu);
        }
        public void ShowEmployeeDetailsHeader()
        {
            Console.WriteLine("{0,-20} | {1,-10} | {2,-25} | {3,-10} | {4,-15} | {5,-15} | {6,-15} | {7,-10} | {8,-15}", "Name", "EmpNo", "Mail", "Join Date", "Location", "Job Title", "Department", "Manager Id", "Project");
        }
        public void ReadEmployeeIdToShowDetails()
        {
            Console.Write(Constants.EnterEmpNo);
            string empNo = Console.ReadLine();
            List<Employee> Employees = _repository.Get();
            var employeeList = (from emp in Employees where emp.EmpNo == empNo select emp).ToList();
            if (employeeList.Count != 0)
            {
                this.ShowEmployeeDetailsHeader();
                this.ShowEmployeeDetails(employeeList[0]);
            }
            else
            {
                Console.WriteLine(Constants.InvalidEmpNo);
            }
        }
        public void ShowEmployeeDetails(Employee employee)
        {
            Console.WriteLine("{0,-20} | {1,-10} | {2,-25} | {3,-10} | {4,-15} | {5,-15} | {6,-15} | {7,-10} | {8,-15}", employee.FirstName + " " + employee.LastName, employee.EmpNo, employee.EmpMail, employee.JoiningDate, employee.Location, employee.JobTitle, employee.Department, employee.Manager, employee.Project);
        }
        public void DeleteEmployeeDetails()
        {
            Console.Write(Constants.EnterEmpNo);
            string empNo = Console.ReadLine();
            List<Employee> Employees = _repository.Get();
            var employeeList = (from emp in Employees where emp.EmpNo == empNo select emp).ToList();
            if (employeeList.Count != 0)
            {
                for (int i = 0; i < Employees.Count; i++)
                {
                    if (Employees[i].EmpNo == empNo)
                    {
                        Employees.RemoveAt(i);
                        break;
                    }
                }
                _repository.Store(Employees);
                Console.WriteLine("Employee Details removed Successfuylly! ");
            }
            else
            {
                Console.WriteLine(Constants.InvalidEmpNo);
            }
        }
        public void EmployeeManagement()
        {
            int option;
            bool isProvidingService = true;
            while (isProvidingService)
            {
                EmployeeServices.EmployeeDisplayOptions();
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        this.AddEmployeeDetails();
                        break;
                    case 2:
                        this.EditEmployeeDetails();
                        break;
                    case 3:
                        this.ReadEmployeeIdToShowDetails();
                        break;
                    case 4:
                        List<Employee> Employees = _repository.Get();
                        this.ShowEmployeeDetailsHeader();
                        foreach (var emp in Employees)
                        {
                            this.ShowEmployeeDetails(emp);
                        }
                        break;
                    case 5:
                        this.DeleteEmployeeDetails();
                        break;
                    case 6:
                        isProvidingService = false;
                        break;
                }
            }
        }
    }
}
