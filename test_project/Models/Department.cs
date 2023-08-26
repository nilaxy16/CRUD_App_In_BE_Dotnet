using System.ComponentModel.DataAnnotations;

namespace test_project.Models
{
    public class Department
    {
        [Key] public string? DeptId { get; set; }
        public string? DeptName { get; set; }
    }
}
