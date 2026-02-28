using MediatRwebApiASPCorewithEF.Dto;
using MediatRwebApiASPCorewithEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediatRwebApiASPCorewithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext studentDb;

        public StudentController(StudentDbContext studentDb)
        {
            this.studentDb = studentDb;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentResponseDto>>> GetStudents()
        {
            var students = await studentDb.Students
                .Include(s => s.Addresses)
                .Where(s => s.IsDeleted != "X" || s.IsDeleted == null)
                .ToListAsync();

            var response = students.Select(s => new StudentResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Gender = s.Gender,
                Standard = s.Standard,
                Addresses = s.Addresses.Select(a => new AddressResponseDto
                {
                    HouseNo = a.HouseNo,
                    Street = a.Street,
                    District = a.District,
                    State = a.State,
                    IsPermanent = a.IsPermanent
                }).ToList()
            }).ToList();

            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponseDto>> GetStudentById(int id)
        {
            var student = await studentDb.Students
                .Include(s => s.Addresses)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != "X");

            if (student == null)
                return NotFound();

            var response = new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Gender = student.Gender,
                Standard = student.Standard,
                Addresses = student.Addresses.Select(a => new AddressResponseDto
                {
                    HouseNo = a.HouseNo,
                    Street = a.Street,
                    District = a.District,
                    State = a.State,
                    IsPermanent = a.IsPermanent
                }).ToList()
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(StudentCreateDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Gender = dto.Gender,
                Standard = dto.Standard,
                IsDeleted = null,
                Addresses = new List<Address>
            {
            new Address
            {
                HouseNo = dto.PermanentAddress.HouseNo,
                Street = dto.PermanentAddress.Street,
                District = dto.PermanentAddress.District,
                State = dto.PermanentAddress.State,
                IsPermanent = "Y"
            },
            new Address
            {
                HouseNo = dto.TemporaryAddress.HouseNo,
                Street = dto.TemporaryAddress.Street,
                District = dto.TemporaryAddress.District,
                State = dto.TemporaryAddress.State,
                IsPermanent = "N"
            }
        }
            };

            await studentDb.Students.AddAsync(student);
            await studentDb.SaveChangesAsync();

            return Ok(student);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            studentDb.Entry(student).State = EntityState.Modified;
            await studentDb.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await studentDb.Students
                .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted != "X");

            if (student == null)
            {
                return NotFound();
            }

            student.IsDeleted = "X";
            await studentDb.SaveChangesAsync();

            return NoContent(); // 204
        }

    }
}
