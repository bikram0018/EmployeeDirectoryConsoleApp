using System;
using EmployeeDirectory.Services.Interfaces;
using Newtonsoft.Json;
using EmployeeDirectory.Models.Constants;
namespace EmployeeDirectory.Services.Repositories
{
    public class EmployeeRepository<T> : IRepository<T>
    {
        string _empDetailsPath = Constants.EmpDetialsPath;
        public List<T> Get()
        {
            if (File.Exists(_empDetailsPath))
            {
                var data = File.ReadAllText(_empDetailsPath);
                List<T> Employees = JsonConvert.DeserializeObject<List<T>>(data);
                return Employees ?? [];
            }
            else {
                File.Create(_empDetailsPath);
                return [];
            }
        }
        public void Store(List<T> Employees)
        {
            var jsonFile = JsonConvert.SerializeObject(Employees);
            File.WriteAllText(_empDetailsPath, jsonFile);
        }
    }
}
