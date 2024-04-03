using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Models
{
    public class Employee
    {
        public string EmpNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string EmpMail { get; set; }
        public long MobileNumber { get; set; }
        public DateOnly JoiningDate { get; set; }
        public string RoleId {  get; set; }
        public string Location {  get; set; }
        public string JobTitle {  get; set; }
        public string Department {  get; set; }
        public string Manager {  get; set; }
        public string Project {  get; set; }
    }
}
