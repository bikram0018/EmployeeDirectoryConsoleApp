using System;
using EmployeeDirectory.Models;

namespace EmployeeDirectory.Services.Interfaces
{
    public interface IEmployeeServices
    {
        void AddEmployeeDetails();
        void EditEmployeeDetails();
        void DeleteEmployeeDetails();
        void ShowEmployeeDetailsHeader();
        void ShowEmployeeDetails(Employee emp);
        void EmployeeManagement();
    }
}
