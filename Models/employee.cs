using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrDep.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; } = null!;
        public double Salary { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
    }
    public class Job
    {
        public int JobId { get; set; }
        public string JobName { get; set; } = null!;
        public double MinSalary { get; set; }
        public double MaxSalary { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public string? Location { get; set; }
        public int EmployeeCount { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
