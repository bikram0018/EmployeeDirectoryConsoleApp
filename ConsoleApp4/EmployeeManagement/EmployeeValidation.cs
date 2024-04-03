using System.Text.RegularExpressions;

namespace EmployeeDirectory.servicees
{
    public class EmployeeDetailsValidation
    {
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
            DateOnly maxdate = DateOnly.FromDateTime(DateTime.Now);
            maxdate = maxdate.AddYears(-22);
            if (date.CompareTo(maxdate) > 0)
            {
                return false;
            }
            return true;
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
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            if (date.CompareTo(today) > 0)
            {
                return false;
            }
            return true;
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
            return ValidateLocation(department);
        }
        public static bool ValidateManager(string managerId)
        {

            if (EmployeeServices.GetEmployeeDetials().ContainsKey(managerId))
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
