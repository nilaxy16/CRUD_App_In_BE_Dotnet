using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_project.Models;

namespace test_project.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StudentController: ControllerBase
    {
        private StudentsAPIDbContext DbContext;

        public StudentController(StudentsAPIDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await DbContext.Students.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(Student addStudentRequest)
        {
            var student = new Student()
            {
                StudentId = addStudentRequest.StudentId,
                FullName = addStudentRequest.FullName,
                Mobile = addStudentRequest.Mobile
            };
            await DbContext.Students.AddAsync(student);
            await DbContext.SaveChangesAsync();
            return Ok(student);
        }

        [HttpGet]
        [Route("{StudentId}")]
        public async Task<IActionResult> GetContact([FromRoute] string StudentId)
        {
            var student = await DbContext.Students.FindAsync(StudentId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPut]
        [Route("{StudentId}")]
        public async Task<IActionResult> UpdateContact([FromRoute] string StudentId, Student updateStudentRequest)
        {
            var student = await DbContext.Students.FindAsync(StudentId);
            if (student != null)
            {
                student.FullName = updateStudentRequest.FullName;
                student.Mobile = updateStudentRequest.Mobile;
                await DbContext.SaveChangesAsync();
                return Ok(student);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{StudentId}")]
        public async Task<IActionResult> DeleteContact(string StudentId)
        {
            var student = await DbContext.Students.FindAsync(StudentId);
            if (student != null)
            {
                DbContext.Remove(student);
                DbContext.SaveChanges();
                return Ok(student);
            }
            return NotFound();
        }
    }
}
