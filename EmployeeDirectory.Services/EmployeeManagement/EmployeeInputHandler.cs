using System;
using System.Data;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Interfaces;
using EmployeeDirectory.Models.Constants;
namespace EmployeeDirectory.Services.EmployeeManagement
{
    public class EmployeeInputHandler
    {
        public readonly IRepository<Employee> _empRepository;
        public readonly IRepository<Role> _roleRepository;
        public EmployeeInputHandler(IRepository<Employee> EmpRepoService, IRepository<Role> RoleRepoService)
        {
            _empRepository = EmpRepoService;
            _roleRepository = RoleRepoService;
        }
        public Employee ReadEmployeeDetails()
        {
            string empNo, firstName, lastName, empMail, roleId, location, jobTitle, department, manager, project;
            DateOnly dateOfBirth, joiningDate;
            long mobileNumber;
            int option = 0;
            // employee number input
            empNo = this.EmployeeNumberInput();
            // first name input
            firstName = this.EmployeeFirstNameInput();
            // last name input
            lastName = this.EmployeeLastNameInput();
            // date of birth input
            dateOfBirth = default;
            while (option <= 0 || option > 2)
            {
                Console.WriteLine("Do you want to enter date of birth ");
                Console.WriteLine(Constants.EnterOrSkipOptions);
                int.TryParse(Console.ReadLine(), out option);
                if (option == 1)
                {
                    dateOfBirth = this.EmployeeDateofBirthInput();
                    break;
                }
                else if (option == 2) { break; }
                else { Console.WriteLine(Constants.ChooseFromOptions); }
            }
            // employee mail input
            empMail = this.EmployeeMailInput();
            // mobile number input
            option = 0; mobileNumber = default;
            while (option <= 0 || option > 2)
            {
                Console.WriteLine("Do you want to enter mobile number ");
                Console.WriteLine(Constants.EnterOrSkipOptions);
                int.TryParse(Console.ReadLine(), out option);
                if (option == 1)
                {
                    mobileNumber = this.EmployeeMobileNumberInput();
                    break;
                }
                else if (option == 2) { break; }
                else { Console.WriteLine(Constants.ChooseFromOptions); }
            }
            // joining date input
            joiningDate = this.EmployeeJoinDateInput();
            // RoleId input
            option = 0;
            roleId = default;
            while (option <= 0 || option > 2)
            {
                Console.WriteLine("Do you want to enter Role Id ");
                Console.WriteLine(Constants.EnterOrSkipOptions);
                int.TryParse(Console.ReadLine(), out option);
                if (option == 1)
                {
                    roleId = this.EmployeeRoleIdInput();
                    break;
                }
                else if (option == 2) { break; }
                else{ Console.WriteLine(Constants.ChooseFromOptions); }
            }
            // auto fill location and department and jobtitle if roleid is valid
            if (!string.IsNullOrEmpty(roleId))
            {
                Role roleValues = this.GetRoleValues(roleId);
                location = roleValues.Location;
                jobTitle = roleValues.RoleName;
                department = roleValues.Department;
            }
            else {
                // location input
                location = this.EmployeeLocationInput();
                // job title input
                jobTitle = this.EmployeeJobTitleInput(location);
                // Department input
                department = this.EmployeeDepartmentInput(location,jobTitle);

                roleId = this.GetRoleId(location, jobTitle, department);
            }
            // Manager input
            option = 0; manager = null;
            while (option <= 0 || option > 2)
            {
                Console.WriteLine("Do you want to enter Manager id ");
                Console.WriteLine(Constants.EnterOrSkipOptions);
                int.TryParse(Console.ReadLine(), out option);
                if (option == 1)
                {
                    manager = this.EmployeeManagerIdInput();
                    break;
                }
                else if (option == 2)
                {
                    manager = null;
                    break;
                }
                else { Console.WriteLine(Constants.ChooseFromOptions); }
            }
            // project input
            option = 0; project = null;
            while (option <= 0 || option > 2)
            {
                Console.WriteLine("Do you want to enter project name");
                Console.WriteLine(Constants.EnterOrSkipOptions);
                int.TryParse(Console.ReadLine(), out option);
                if (option == 1)
                {
                    project = this.EmployeeProjectNameInput();
                    break;
                }
                else if (option == 2)
                {
                    project = null;
                    break;
                }
                else
                {
                    Console.WriteLine(Constants.ChooseFromOptions);
                }
            }
            Employee employee = this.AssignEmployeeValues(empNo, firstName, lastName, dateOfBirth, empMail, mobileNumber, joiningDate, roleId, location, jobTitle, department, manager, project);
            return employee;
        }

        public Employee AssignEmployeeValues(string empNo, string firstName, string lastName, DateOnly dateOfBirth, string empMail, long mobileNumber, DateOnly joiningDate, string RoleId, string location, string jobTitle, string department, string manager, string project)
        {
            Employee employee = new Employee();
            employee.EmpNo = empNo;
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.DateOfBirth = dateOfBirth;
            employee.EmpMail = empMail;
            employee.MobileNumber = mobileNumber;
            employee.JoiningDate = joiningDate;
            employee.RoleId = RoleId;
            employee.Location = location;
            employee.JobTitle = jobTitle;
            employee.Department = department;
            employee.Manager = manager;
            employee.Project = project;
            return employee;
        }
        public string GetRoleId(string location, string jobTitle, string department)
        {
            List<Role> Roles = _roleRepository.Get();
            try {
                var queryResult = (from role in Roles where role.Location == location && role.RoleName == jobTitle && role.Department == department select role).Single();
                return queryResult.RoleName;
            }
            catch (Exception ex) {
                return string.Empty;
            }
        }
        public string EmployeeNumberInput()
        {
            string empNo;
            while (true)
            {
                Console.Write(Constants.EnterEmpNo);
                empNo = Console.ReadLine();
                List<Employee> Employees = _empRepository.Get();
                var employeeList = (from emp in Employees where emp.EmpNo == empNo select emp).ToList() ?? [];
                if (employeeList.Count != 0)
                {
                    Console.WriteLine("Employee Number already Exists!!");
                }
                else if (EmployeeDetailsValidation.ValidateEmployeeNumber(empNo)) { break; }
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
                if (EmployeeDetailsValidation.ValidateName(firstName)) { break; }
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
                if (EmployeeDetailsValidation.ValidateName(lastName)) { break; }
                else { Console.WriteLine("Invalid Name!!"); }
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
                DateTime dob = default;
                if (arr.Length == 3)
                {
                    DateTime.TryParse(arr[1] + '/' + arr[0] + '/' + arr[2], out dob);
                }
                dateOfBirth = DateOnly.FromDateTime(dob);
                if (EmployeeDetailsValidation.ValidateDateOfBirth(dateOfBirth)) { break; }
                else { Console.WriteLine("Invalid Date!!"); }
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
                if (EmployeeDetailsValidation.ValidateEmail(empMail)) { break; }
                else { Console.WriteLine("Invalid Mail!!"); }
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
                if (EmployeeDetailsValidation.ValidateMobileNumber(mobileNumber)) { break; }
                else { Console.WriteLine("Invalid Mobile Number!!"); }
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
                DateTime joinDate = default;
                if (arr.Length == 3)
                {
                    DateTime.TryParse(arr[1] + '/' + arr[0] + '/' + arr[2], out joinDate);
                }
                joiningDate = DateOnly.FromDateTime(joinDate);
                if (EmployeeDetailsValidation.ValidateJoiningDate(joiningDate)) { break; }
                else { Console.WriteLine("Invalid Joining Date!!"); }
            }
            return joiningDate;
        }
        public string EmployeeRoleIdInput() {
            List<Role> Roles = _roleRepository.Get();
            string roleId;
            while (true)
            {
                Console.Write("Enter the RoleId : ");
                roleId = Console.ReadLine();

                var queryResult = from role in Roles where role.RoleId == roleId select role;
                if (queryResult.Count() == 1) { break; }
                else { Console.WriteLine("Invalid RoleId!!"); }
            }
            return roleId;
        }
        public Role GetRoleValues(string roleId) { 
            List<Role> Roles = _roleRepository.Get();
            var queryResult = (from role in Roles where role.RoleId==roleId select role).Single();
            Role _role = new Role();
            _role.RoleId = roleId;
            _role.RoleName = queryResult.RoleName;
            _role.Location = queryResult.Location;
            _role.Department = queryResult.Department;
            return _role;
        }
        public string EmployeeLocationInput()
        {
            List<Role> Roles = _roleRepository.Get();
            var queryResult = (from role in Roles select role.Location).Distinct();
            string location=default;
            int count, option = 0;
            while (true)
            {

                Console.WriteLine("select a location : ");
                count = 0;
                foreach (var loc in queryResult)
                {
                    count++;
                    Console.WriteLine(count + " . " + loc);
                }
                int.TryParse(Console.ReadLine(), out option);
                if (option>0 && option<=count)
                {
                    count = 0;
                    foreach (var loc in queryResult)
                    {
                        count++;
                        if (option == count) { location = loc; }
                    }
                    break;
                }
                else{ Console.WriteLine("Invalid Location!!"); }
            }
            return location;
        }
        public string EmployeeJobTitleInput(string location)
        {
            Console.WriteLine(location);
            List<Role> Roles = _roleRepository.Get();
            var queryResult = (from role in Roles where location == role.Location select role.RoleName).Distinct();
            string jobTitle=default;
            int count, option = 0;
            while (true)
            {
                count = 0;
                Console.WriteLine("select Employee JobTitle : ");
                foreach (var roleName in queryResult)
                {
                    count++;
                    Console.WriteLine(count + " . " + roleName);
                }
                int.TryParse(Console.ReadLine(), out option);
                if (option>0 && option<=count)
                {
                    count = 0;
                    foreach (var roleName in queryResult)
                    {
                        count++;
                        if (option == count) { jobTitle=roleName; }
                    }
                    break;
                }
                else { Console.WriteLine("Invalid Job Title!!"); }
            }
            return jobTitle;
        }
        public string EmployeeDepartmentInput(string location, string roleName)
        {
            string department = default;
            int option,count;
            List<Role> Roles = _roleRepository.Get();
            var queryResult = (from role in Roles where location == role.Location && roleName == role.RoleName select role.Department).Distinct();
            while (true)
            {
                Console.WriteLine("Select a Department : ");
                count = 0;
                foreach (var roleDept in queryResult)
                {
                    count++;
                    Console.WriteLine(count + " . " + roleDept);
                }
                int.TryParse(Console.ReadLine(), out option);
                if (option > 0 && option<=count)
                {
                    count = 0;
                    foreach (var roleDept in queryResult)
                    {
                        count++;
                        if (count == option) { department = roleDept; }
                    }
                    break;
                }
                else { Console.WriteLine("Select a valid Department!!"); }
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
                if (EmployeeDetailsValidation.ValidateManager(manager)) { break; }
                else { Console.WriteLine("Invalid Manager Id!!"); }
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
                if (option > 0 && option <= Constants.Projects.Count)
                {
                    project = Constants.Projects[option - 1];
                    if (EmployeeDetailsValidation.ValidateProject(project)) { break; }
                    else { Console.WriteLine("Invalid Project Name!!"); }
                }
                else { Console.WriteLine("Select a valid project!!"); }
            }
            return project;
        }
    }
}
