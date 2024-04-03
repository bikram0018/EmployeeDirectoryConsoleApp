using System;
using Newtonsoft.Json;
using EmployeeDirectory.Models;
namespace EmployeeDirectory.servicees
{
    public class Repository
    {
        public static string empDetailsPath = "C:\\Users\\bikram.b\\Desktop\\Internship\\Data\\employeetextdata.txt";
        public static string rolesDetailsPath = "C:\\Users\\bikram.b\\Desktop\\Internship\\Data\\rolestextdata.txt";
        public static void StoreEmployeeDetails(Dictionary<string, Employee> Employees)
        {
            var jsonFile = JsonConvert.SerializeObject(Employees);
            File.WriteAllText(empDetailsPath, jsonFile);
        }
        public static Dictionary<string, Employee> LoadEmployeeDetails()
        {
            var data = File.ReadAllText(empDetailsPath);
            Dictionary<string, Employee> Employees = JsonConvert.DeserializeObject<Dictionary<string, Employee>>(data);
            return Employees;
        }
        public static void StoreRolesDetails(List<Role> Roles)
        {
            var jsonFile = JsonConvert.SerializeObject(Roles);
            File.WriteAllText(rolesDetailsPath, jsonFile);
        }
        public static List<Role> LoadRolesDetails()
        {
            var data = File.ReadAllText(rolesDetailsPath);
            List<Role> Roles = JsonConvert.DeserializeObject<List<Role>>(data);
            return Roles;
        }
    }
}
