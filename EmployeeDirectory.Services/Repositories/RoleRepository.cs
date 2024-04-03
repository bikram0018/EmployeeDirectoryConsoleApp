using System;
using EmployeeDirectory.Models.Constants;
using EmployeeDirectory.Services.Interfaces;
using Newtonsoft.Json;

namespace EmployeeDirectory.Services.Repositories
{
    public class RoleRepository<T> : IRepository<T>
    {
        string _rolesDetailsPath = Constants.RoleDetailsPath;
        public List<T> Get()
        {
            if (File.Exists(_rolesDetailsPath))
            {
                var data = File.ReadAllText(_rolesDetailsPath);
                List<T> Roles = JsonConvert.DeserializeObject<List<T>>(data);
                return Roles ?? [];
            }
            else {
                File.Create(_rolesDetailsPath);
                return []; 
            }
        }
        public void Store(List<T> Roles)
        {
            var jsonFile = JsonConvert.SerializeObject(Roles);
            File.WriteAllText(_rolesDetailsPath, jsonFile);
        }
    }
}
