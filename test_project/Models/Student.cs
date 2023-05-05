using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_project.Models
{
    public class Student
    {
        //[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        //public int No { get; set; }

        [Key]
        public string StudentId { get; set; }

        public string FullName { get; set; }

        public string Mobile { get; set; }
    }
}
