using System.Transactions;
using EmployeeDirectory.Models;
namespace EmployeeDirectory.servicees
{
    public class EmployeeServices
    {
        public EmployeeServices() {
            Employees = Repository.LoadEmployeeDetails();
        }
        private static Dictionary<string, Employee> Employees = new Dictionary<string, Employee>();
        public static Dictionary<string, Employee> GetEmployeeDetials() { 
            return Employees;
        }
        public Employee ReadEmployeeDetails()
        {
            EmployeeServices readEmpData = new EmployeeServices();
            string empNo, firstName, lastName, empMail, location, jobTitle, department, manager, project;
            DateOnly dateOfBirth, joiningDate;
            long mobileNumber;
            int option;
            // employee number input
            empNo = readEmpData.EmployeeNumberInput();
            // first name input
            firstName = readEmpData.EmployeeFirstNameInput();
            // last name input
            lastName = readEmpData.EmployeeLastNameInput();
            // date of birth input
            Console.WriteLine("Do you want to enter date of birth ");
            Console.WriteLine("1.Enter Manually \n2.Skip");
            int.TryParse(Console.ReadLine(), out option);
            if (option == 1)
            {
                dateOfBirth = readEmpData.EmployeeDateofBirthInput();
            }
            else
            {
                dateOfBirth = new DateOnly(1, 1, 1);
            }
            // employee mail input
            empMail = readEmpData.EmployeeMailInput();
            // mobile number input
            Console.WriteLine("Do you want to enter mobile number ");
            Console.WriteLine("1.Enter Manually \n2.Skip");
            int.TryParse(Console.ReadLine(), out option);
            if (option == 1)
            {
                mobileNumber = readEmpData.EmployeeMobileNumberInput();
            }
            else
            {
                mobileNumber = 0;
            }
            // joining date input
            joiningDate = readEmpData.EmployeeJoinDateInput();
            // location input
            location = readEmpData.EmployeeLocationInput();
            // job title input
            jobTitle = readEmpData.EmployeeJobTitleInput();
            // Department input
            department = readEmpData.EmployeeDepartmentInput();
            // Manager input
            Console.WriteLine("Do you want to enter Manager id ");
            Console.WriteLine("1. Enter manually \n2. Skip");
            int.TryParse(Console.ReadLine(), out option);
            if (option == 1)
            {
                manager = readEmpData.EmployeeManagerIdInput();
            }
            else
            {
                manager = null;
            }
            // project input
            Console.WriteLine("Do you want to enter project name");
            Console.WriteLine("1.Enter Manually \n2.Skip");
            int.TryParse(Console.ReadLine(), out option);
            if (option == 1)
            {
                project = readEmpData.EmployeeProjectNameInput();
            }
            else
            {
                project = null;
            }
            Employee employee = readEmpData.AssignEmployeeValues(empNo, firstName, lastName, dateOfBirth, empMail, mobileNumber, joiningDate, location, jobTitle, department, manager, project);
            return employee;
        }
        public Employee AssignEmployeeValues(string empNo,string firstName,string lastName,DateOnly dateOfBirth,string empMail,long mobileNumber,DateOnly joiningDate,string location,string jobTitle,string department,string manager,string project) {
            Employee employee = new Employee();
            employee.EmpNo = empNo;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.DateOfBirth = dateOfBirth;
            employee.EmpMail = empMail;
            employee.MobileNumber = mobileNumber;
            employee.JoiningDate = joiningDate;
            employee.Location = location;
            employee.JobTitle = jobTitle;
            employee.Department = department;
            employee.Manager = manager;
            employee.Project = project;
            return employee;
        }
        public void AddEmployeeDetails()
        {
            Employee employee = this.ReadEmployeeDetails();
            EmployeeServices.Employees.Add(employee.EmpNo, employee);
            Console.WriteLine("Employee Added Successfully! ");
        }
        public void EditEmployeeDetails()
        {
            Console.Write(Constants.EnterEmpNo);
            string empNo = Console.ReadLine();
            if (EmployeeServices.Employees.ContainsKey(empNo))
            {
                Employee employee = EmployeeServices.Employees[empNo];
                EmployeeServices readEmpData = new EmployeeServices();
                int option;
                bool isProvidingService = true;
                while (isProvidingService)
                {
                    EmployeeServices.EmployeeEditDispalyOptions();
                    int.TryParse(Console.ReadLine(), out option);
                    switch (option)
                    {
                        case 1:
                            employee.FirstName = readEmpData.EmployeeFirstNameInput();
                            employee.LastName = readEmpData.EmployeeLastNameInput();
                            break;
                        case 2:
                            employee.DateOfBirth = readEmpData.EmployeeDateofBirthInput();
                            break;
                        case 3:
                            employee.EmpMail = readEmpData.EmployeeMailInput();
                            break;
                        case 4:
                            employee.MobileNumber = readEmpData.EmployeeMobileNumberInput();
                            break;
                        case 5:
                            employee.JoiningDate = readEmpData.EmployeeJoinDateInput();
                            break;
                        case 6:
                            employee.Location = readEmpData.EmployeeLocationInput();
                            break;
                        case 7:
                            employee.JobTitle = readEmpData.EmployeeJobTitleInput();
                            break;
                        case 8:
                            employee.Department = readEmpData.EmployeeDepartmentInput();
                            break;
                        case 9:
                            employee.Manager = readEmpData.EmployeeManagerIdInput();
                            break;
                        case 10:
                            employee.Project = readEmpData.EmployeeProjectNameInput();
                            break;
                        case 11:
                            isProvidingService = false;
                            break;
                    }
                }
                EmployeeServices.Employees[empNo] = employee;
                Repository.StoreEmployeeDetails(EmployeeServices.Employees);
                Console.WriteLine("Employee Detials Updated Successfully! ");
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
        public void GetEmployeeIdToShowDetails()
        {
            Console.Write(Constants.EnterEmpNo);
            string empNo = Console.ReadLine();
            if (EmployeeServices.Employees.ContainsKey(empNo))
            {
                Console.WriteLine("{0,-20} | {1,-10} | {2,-25} | {3,-10} | {4,-15} | {5,-15} | {6,-15} | {7,-10} | {8,-15}", "Name", "EmpNo", "Mail", "Join Date", "Location", "Job Title", "Department", "Manager Id", "Project");
                this.ShowEmployeeDetails(EmployeeServices.Employees[empNo]);
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
            if (EmployeeServices.Employees.ContainsKey(empNo))
            {
                EmployeeServices.Employees.Remove(empNo);
                Console.WriteLine("Employee Details removed Successfuylly! ");
            }
            else
            {
                Console.WriteLine(Constants.InvalidEmpNo);
            }
        }
        public string EmployeeNumberInput()
        {
            string empNo;
            while (true)
            {
                Console.Write(Constants.EnterEmpNo);
                empNo = Console.ReadLine();
                if (EmployeeServices.Employees.ContainsKey(empNo))
                {
                    Console.WriteLine("Employee Number already Exists!!");
                }
                else if (EmployeeDetailsValidation.ValidateEmployeeNumber(empNo))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(Constants.InvalidEmpNo);
                }
            }
            return empNo;
        }
        public string EmployeeFirstNameInput()
        {
            string firstName;
            while (true)
            {
                Console.Write("Enter Employee First Name : ");
                firstName = Console.ReadLine();
                if (EmployeeDetailsValidation.ValidateName(firstName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Name!!");
                }
            }
            return firstName;
        }
        public string EmployeeLastNameInput()
        {
            string lastName;
            while (true)
            {
                Console.Write("Enter Employee Last Name : ");
                lastName = Console.ReadLine();
                if (EmployeeDetailsValidation.ValidateName(lastName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Name!!");
                }
            }
            return lastName;
        }
        public DateOnly EmployeeDateofBirthInput()
        {
            DateOnly dateOfBirth;
            while (true)
            {
                Console.Write("Enter Employee Date of Birth : ");
                String s = Console.ReadLine();
                string[] arr = s.Split("/");
                dateOfBirth = DateOnly.FromDateTime(Convert.ToDateTime(arr[1] + '/' + arr[0] + '/' + arr[2]));
                if (EmployeeDetailsValidation.ValidateDateOfBirth(dateOfBirth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Date!!");
                }
            }
            return dateOfBirth;
        }
        public string EmployeeMailInput()
        {
            string empMail;
            while (true)
            {
                Console.Write("Enter Employee Mail : ");
                empMail = Console.ReadLine();
                if (EmployeeDetailsValidation.ValidateEmail(empMail))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Mail!!");
                }
            }
            return empMail;
        }
        public long EmployeeMobileNumberInput()
        {
            long mobileNumber;
            while (true)
            {
                Console.Write("Enter Employee Mobile Number : ");
                mobileNumber = Convert.ToInt64(Console.ReadLine());
                if (EmployeeDetailsValidation.ValidateMobileNumber(mobileNumber))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Mobile Number!!");
                }
            }
            return mobileNumber;
        }
        public DateOnly EmployeeJoinDateInput()
        {
            DateOnly joiningDate;
            while (true)
            {
                Console.Write("Enter Employee Joining Date : ");
                String s = Console.ReadLine();
                string[] arr = s.Split("/");
                joiningDate = DateOnly.FromDateTime(Convert.ToDateTime(arr[1] + '/' + arr[0] + '/' + arr[2]));
                if (EmployeeDetailsValidation.ValidateJoiningDate(joiningDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Joining Date!!");
                }
            }
            return joiningDate;
        }
        public string EmployeeLocationInput()
        {
            string location;
            while (true)
            {
                Console.Write("Enter location : ");
                location = Console.ReadLine();
                if (EmployeeDetailsValidation.ValidateLocation(location))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Location!!");
                }
            }
            return location;
        }
        public string EmployeeJobTitleInput()
        {
            string jobTitle;
            while (true)
            {
                Console.Write("Enter Employee JobTitle : ");
                jobTitle = Console.ReadLine();
                if (EmployeeDetailsValidation.ValidateJobTitle(jobTitle))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Job Title!!");
                }
            }
            return jobTitle;
        }
        public string EmployeeDepartmentInput()
        {
            string department;
            int option;
            while (true)
            {
                Console.WriteLine("Select a Department : ");
                for (int i = 0; i < Constants.Departments.Count; i++)
                {
                    Console.WriteLine("{0} : {1} ", i + 1, Constants.Departments[i]);
                }
                int.TryParse(Console.ReadLine(), out option);
                Console.WriteLine(option);
                if (option>0 & option <= Constants.Departments.Count)
                {
                    department = Constants.Projects[option - 1];
                    if (EmployeeDetailsValidation.ValidateProject(department))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Project Name!!");
                    }
                }
                else
                {
                    Console.WriteLine("Select a valid Department!!");
                }
            }
            return department;

        }
        public string EmployeeManagerIdInput()
        {
            string manager;
            while (true)
            {
                Console.Write("Enter manager id : ");
                manager = Console.ReadLine();
                if (EmployeeDetailsValidation.ValidateManager(manager))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Manager Id!!");
                }
            }
            return manager;
        }
        public string EmployeeProjectNameInput()
        {
            string project;
            int option;
            while (true)
            {
                Console.WriteLine("Select a project : ");
                for (int i = 0; i < Constants.Projects.Count; i++)
                {
                    Console.WriteLine("{0} : {1} ", i + 1, Constants.Projects[i]);
                }
                int.TryParse(Console.ReadLine(), out option);
                if (option>0 && option <= Constants.Projects.Count)
                {
                    project = Constants.Projects[option - 1];
                    if (EmployeeDetailsValidation.ValidateProject(project))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Project Name!!");
                    }
                }
                else { 
                    Console.WriteLine("Select a valid project!!");
                }
            }
            return project;
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
                        Repository.StoreEmployeeDetails(EmployeeServices.Employees);
                        break;
                    case 2:
                        this.EditEmployeeDetails();
                        Repository.StoreEmployeeDetails(EmployeeServices.Employees);
                        break;
                    case 3:
                        this.GetEmployeeIdToShowDetails();
                        break;
                    case 4:
                        Console.WriteLine("{0,-20} | {1,-10} | {2,-25} | {3,-10} | {4,-15} | {5,-15} | {6,-15} | {7,-10} | {8,-15}", "Name", "EmpNo", "Mail", "Join Date", "Location", "Job Title", "Department", "Manager Id", "Project");
                        foreach (var key in EmployeeServices.Employees.Keys)
                        {
                            this.ShowEmployeeDetails(EmployeeServices.Employees[key]);
                        }
                        break;
                    case 5:
                        this.DeleteEmployeeDetails();
                        Repository.StoreEmployeeDetails(EmployeeServices.Employees);
                        break;
                    case 6:
                        isProvidingService = false;
                        break;
                }
            }
        }
    }
}