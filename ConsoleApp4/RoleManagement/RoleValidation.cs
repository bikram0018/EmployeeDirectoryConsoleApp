using System.Text.RegularExpressions;

namespace EmployeeDirectory.servicees
{
    public class RoleValidation
    {
        public static bool ValidateRoleName(string roleName)
        {
            string pattern = @"[^A-Za-z\s]";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(roleName) || roleName.Length == 0)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateRoleDepartmentName(string department)
        {
            string pattern = "[^A-Za-z]";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(department) || department.Length == 0)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateRoleLocationName(string location)
        {
            return ValidateRoleDepartmentName(location);
        }
    }
}
