using System;
using EmployeeDirectory.Services.EmployeeManagement;
using EmployeeDirectory.Services.RoleManagement;
using EmployeeDirectory.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using EmployeeDirectory.Services.Repositories;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args) { 
            var services= new ServiceCollection();
            services.AddTransient<IEmployeeServices,EmployeeServices>();
            services.AddTransient<IRoleServices, RoleServices>();
            services.AddTransient<IRepository<Employee>, EmployeeRepository<Employee>>();
            services.AddTransient<IRepository<Role>, RoleRepository<Role>>();
            services.AddTransient<IStartApp, EmployeeDirectoryApplication>();
            services.AddTransient<EmployeeInputHandler>();
            services.AddTransient<RoleInputHandler>();
            var provider = services.BuildServiceProvider();
            var instance = provider.GetService<IStartApp>();
            instance.run();
        }
    }
}
