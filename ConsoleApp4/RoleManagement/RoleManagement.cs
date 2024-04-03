using System.Data;
using EmployeeDirectory.Models;
namespace EmployeeDirectory.servicees
{
    public class RoleManagementServices
    {
        public RoleManagementServices() {
            Roles = Repository.LoadRolesDetails();
            if (Roles == null)
            {
                Roles = [];
            }
        }
        private static List<Role> Roles = new List<Role>();
        public Role ReadRolesInput()
        {
            RoleManagementServices RoleServices = new RoleManagementServices();
            string RoleName, Department, Description, Location;
            RoleName = RoleServices.RolesRoleNameInput();
            Department = RoleServices.RolesDepartmentInput();
            Description = RoleServices.RolesDescriptionInput();
            Location = RoleServices.RolesLocationInput();
            Role role = RoleServices.AssignRoleValues(RoleName, Department, Description, Location);
            return role;
        }
        public Role AssignRoleValues(string RoleName, string Department, string Description, string Location) {
            Role role = new Role();
            role.RoleName = RoleName;
            role.Department = Department;
            role.Description = Description;
            role.Location = Location;
            return role;
        }
        public void AddRole()
        {
            Role Role = this.ReadRolesInput();
            string roleName = Role.RoleName;
            string department = Role.Department;
            string location = Role.Location;
            var queryResult = (from role in Roles where role.RoleName == roleName where role.Department == department where role.Location == location select role).Count();
            if (queryResult == 0)
            {
                Roles.Add(Role);
                Repository.StoreRolesDetails(RoleManagementServices.Roles);
            }
            else
            {
                Console.WriteLine("The Role Already exists!!");
            }
        }
        public void DisplayAll()
        {
            Console.WriteLine("{0,-20} | {1,-20} | {2,-20} | {3}", "RoleName", "Department", "Location", "Description");
            foreach (Role role in Roles)
            {
                Console.WriteLine("{0,-20} | {1,-20} | {2,-20} | {3}", role.RoleName, role.Department, role.Location, role.Description);
            }
        }
        public string RolesRoleNameInput()
        {
            string RoleName;
            while (true)
            {
                Console.Write("Enter Role Name : ");
                RoleName = Console.ReadLine();
                if (RoleValidation.ValidateRoleName(RoleName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid RoleName!!");
                }
            }
            return RoleName;
        }
        public string RolesDepartmentInput()
        {
            string Department;
            while (true)
            {
                Console.Write("Enter Department Name : ");
                Department = Console.ReadLine();
                if (RoleValidation.ValidateRoleDepartmentName(Department))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Department Name!!");
                }
            }
            return Department;
        }
        public string RolesDescriptionInput()
        {
            string Description;
            Console.Write("Discription : ");
            Description = Console.ReadLine();
            return Description;
        }
        public string RolesLocationInput()
        {
            string Location;
            while (true)
            {
                Console.Write("Enter Location Name : ");
                Location = Console.ReadLine();
                if (RoleValidation.ValidateRoleLocationName(Location))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Location Name!!");
                }
            }
            return Location;
        }
        public static void RoleManagementDisplayMenu()
        {
            Console.WriteLine(Constants.RoleManageDisplayMenu);
        }
        public void RoleManagement()
        {
            int option;
            bool isProvidingService = true;
            while (isProvidingService)
            {
                RoleManagementServices.RoleManagementDisplayMenu();
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        this.AddRole();
                        break;
                    case 2:
                        this.DisplayAll();
                        break;
                    case 3:
                        isProvidingService = false;
                        break;
                }
            }
        }
    }
}
