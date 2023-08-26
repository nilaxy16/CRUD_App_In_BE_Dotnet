using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_project.Models
{
    public class Student
    {
        [Key] public string? StudentId { get; set; }

        public string? FullName { get; set; }

        public int Mobile { get; set; }

        [ForeignKey("Departments")] public string? DeptId { get; set; }
    }
}
