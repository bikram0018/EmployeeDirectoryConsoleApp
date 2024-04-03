using System.Text.RegularExpressions;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Interfaces;
using EmployeeDirectory.Models.Constants;

namespace EmployeeDirectory.Services
{
    public class EmployeeDetailsValidation
    {
        private static readonly IRepository<Employee> _repository;
        public static bool ValidateEmployeeNumber(string empNo)
        {
            string pattern = "^TZ[0-9]{4}$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(empNo))
            {
                return true;
            }
            return false;
        }
        public static bool ValidateName(string name)
        {
            string pattern = "^[A-Za-z]+$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(name))
            {
                return false;
            }
            return true;
        }
        public static bool ValidateDateOfBirth(DateOnly date)
        {
            string pattern = @"^([1-9]|0[1-9]|1[1-2])/([1-9]|0[1-9]|[1-2][\d]|3[0-1])/[\d]{4}$";
            Regex regex = new Regex(pattern);
            if (date.ToString() == "1/1/0001") {
                return false;
            }
            else if (regex.IsMatch(date.ToString())) {
                DateOnly maxdate = DateOnly.FromDateTime(DateTime.Now);
                maxdate = maxdate.AddYears(-22);
                if (date.CompareTo(maxdate) > 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public static bool ValidateEmail(string mail)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(mail))
            {
                return false;
            }
            return true;
        }
        public static bool ValidateMobileNumber(long mobileNumber)
        {
            string number = mobileNumber.ToString();
            if (number.Length == 10)
            {
                return true;
            }
            return false;
        }
        public static bool ValidateJoiningDate(DateOnly date)
        {
            string pattern = @"^([1-9]|0[1-9]|1[1-2])/([1-9]|0[1-9]|[1-2][\d]|3[0-1])/[\d]{4}$";
            Regex regex = new Regex(pattern);
            if (date.ToString() == "1/1/0001") {
                return false;
            }
            else if (regex.IsMatch(date.ToString())) {
                DateOnly today = DateOnly.FromDateTime(DateTime.Now);
                if (date.CompareTo(today) > 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public static bool ValidateLocation(string location)
        {
            string pattern = "[^A-Za-z]";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(location) || location.Length == 0)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateJobTitle(string jobTitle)
        {
            return ValidateLocation(jobTitle);
        }
        public static bool ValidateDepartment(string department)
        {
            if (Constants.Departments.Contains(department)) {
                return true;
            }
            return false;
        }
        public static bool ValidateManager(string managerId)
        {
            List<Employee> Employees = _repository.Get();
            var employeeList = (from emp in Employees where emp.EmpNo==managerId select emp).ToList();
            if (employeeList.Count != 0)
            {
                return true;
            }
            return false;
        }
        public static bool ValidateProject(string project)
        {
            if (Constants.Projects.Contains(project))
            {
                return true;
            }
            return false;
        }
    }
}
