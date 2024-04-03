using System;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Services.RoleManagement
{
    public class RoleInputHandler
    {
        public Role ReadRolesInput()
        {
            string RoleId, RoleName, Department, Description, Location;
            RoleId = this.RolesRoleIdInput();
            RoleName = this.RolesRoleNameInput();
            Department = this.RolesDepartmentInput();
            Description = this.RolesDescriptionInput();
            Location = this.RolesLocationInput();
            Role role = this.AssignRoleValues(RoleId, RoleName, Department, Description, Location);
            return role;
        }
        public Role AssignRoleValues(string RoleId, string RoleName, string Department, string Description, string Location)
        {
            Role role = new Role();
            role.RoleId = RoleId;
            role.RoleName = RoleName;
            role.Department = Department;
            role.Description = Description;
            role.Location = Location;
            return role;
        }
        public string RolesRoleIdInput() {
            string RoleId;
            while (true)
            {
                Console.Write("Enter Role Id : ");
                RoleId = Console.ReadLine();
                if (RoleValidation.ValidateRoleId(RoleId)) { break; }
                else { Console.WriteLine("Invalid RoleId!!"); }
            }
            return RoleId;
        }
        public string RolesRoleNameInput()
        {
            string RoleName;
            while (true)
            {
                Console.Write("Enter Role Name : ");
                RoleName = Console.ReadLine();
                if (RoleValidation.ValidateRoleName(RoleName)) { break; }
                else { Console.WriteLine("Invalid RoleName!!"); }
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
                if (RoleValidation.ValidateRoleDepartmentName(Department)) { break; }
                else { Console.WriteLine("Invalid Department Name!!"); }
            }
            return Department;
        }
        public string RolesDescriptionInput()
        {
            string Description;
            Console.Write("Description : ");
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
                if (RoleValidation.ValidateRoleLocationName(Location)) { break; }
                else { Console.WriteLine("Invalid Location Name!!"); }
            }
            return Location;
        }
    }
}
