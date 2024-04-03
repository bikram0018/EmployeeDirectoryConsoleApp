namespace EmployeeDirectory.Models.Constants
{
    public static class Constants
    {
        public static List<string> Departments = ["Finance", "HR", "Sales", "marketing", "Research", "ITServices", "ProductEngineer", "Admin"];
        public static List<string> Projects = ["PixelPerfect", "CodeCrafters", "WebWeavers", "DigitalDynamo", "WebLytics", "ClickCanvas"];
        public static string EmpDisplayMenu = @"Select a option
                        1. Add Employee Details
                        2. Update Employee Details
                        3. Get Employee Details
                        4. Get All Employees Details
                        5. Delete Employee Details
                        6. Go Back";
        public static string EmpEditDisplayMenu = @"Select to edit employee
                        1. Employee Name
                        2. Date of Birth
                        3. Employee Mail
                        4. Mobile Number
                        5. Joining Date
                        6. Role Id
                        7. Location
                        8. Job Title
                        9. Department
                        10. Manager
                        11. Project
                        12. Go Back";
        public static string EmpAppDisplayMenu = @"Select a Option
                        1. Employee Management
                        2. Role Management
                        3. Exit ";
        public static string RoleManageDisplayMenu = @"Select a option
                        1. Add Role
                        2. Display All
                        3. Go Back";
        public static string InvalidEmpNo = "Invalid Employee Number!!";
        public static string EnterEmpNo = "Enter Employee number : ";
        public static string ChooseFromOptions = "Choose among the given options!!";
        public static string EnterOrSkipOptions = "1.Enter Manually \n2.Skip";
        public static string EmpDetialsPath = "C:\\Users\\bikram.b\\Desktop\\Internship\\Data\\employeetextdata.txt";
        public static string RoleDetailsPath = "C:\\Users\\bikram.b\\Desktop\\Internship\\Data\\rolestextdata.txt";
    }
}
