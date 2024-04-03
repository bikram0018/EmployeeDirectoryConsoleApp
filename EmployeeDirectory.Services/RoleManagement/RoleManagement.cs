using System;
using EmployeeDirectory.Models;
using EmployeeDirectory.Services.Interfaces;
using EmployeeDirectory.Models.Constants;

namespace EmployeeDirectory.Services.RoleManagement
{
    public class RoleServices : IRoleServices
    {
        private readonly IRepository<Role> _repository;
        private readonly RoleInputHandler _inputHandler;
        public RoleServices (IRepository<Role> RepoService,RoleInputHandler InputHandler) { 
            _repository = RepoService;
            _inputHandler = InputHandler;
        }
        public void AddRole()
        {
            List<Role> Roles = _repository.Get();
            Role Role = _inputHandler.ReadRolesInput();
            string roleId = Role.RoleId;
            var queryResult = (from role in Roles where role.RoleId==roleId select role).Count();
            if (queryResult == 0)
            {
                Roles.Add(Role);
                _repository.Store(Roles);
            }
            else
            {
                Console.WriteLine("The Role Already exists!!");
            }
        }
        public void DisplayAllRoles()
        {
            List<Role> Roles = _repository.Get();
            Console.WriteLine("{0,-20} | {1,-20} | {2,-20} | {3,-20} | {4}", "RoleId","RoleName", "Department", "Location", "Description");
            foreach (Role role in Roles)
            {
                Console.WriteLine("{0,-20} | {1,-20} | {2,-20} | {3,-20} | {4}", role.RoleId, role.RoleName, role.Department, role.Location, role.Description);
            }
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
                RoleServices.RoleManagementDisplayMenu();
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        this.AddRole();
                        break;
                    case 2:
                        this.DisplayAllRoles();
                        break;
                    case 3:
                        isProvidingService = false;
                        break;
                }
            }
        }
    }
}
