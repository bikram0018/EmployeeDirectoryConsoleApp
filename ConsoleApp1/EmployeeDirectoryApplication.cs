using System;
using EmployeeDirectory.Services.Interfaces;
using EmployeeDirectory.Models.Constants;
namespace EmployeeDirectory.ConsoleApp
{
    public class EmployeeDirectoryApplication : IStartApp
    {
        private readonly IEmployeeServices _empServices;
        private readonly IRoleServices _roleServices;
        public EmployeeDirectoryApplication(IEmployeeServices empService,IRoleServices roleService) {
            _empServices = empService;
            _roleServices = roleService;
        }
        public static void EmployeeDirectoryConsoleAppDisplayMenu()
        {
            Console.WriteLine(Constants.EmpAppDisplayMenu);
        }
        public void run()
        {
            int option;
            bool isProvidingService = true;
            while (isProvidingService)
            {
                EmployeeDirectoryApplication.EmployeeDirectoryConsoleAppDisplayMenu();
                int.TryParse(Console.ReadLine(), out option);
                switch (option)
                {
                    case 1:
                        _empServices.EmployeeManagement();
                        break;
                    case 2:
                        _roleServices.RoleManagement();
                        break;
                    case 3:
                        isProvidingService = false;
                        break;
                }
            }
        }
    }
}
