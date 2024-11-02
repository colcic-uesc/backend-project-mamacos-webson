using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http;
using BackEndAPI.Core;
using Microsoft.AspNetCore.Authorization;

namespace UescColcicAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]  // Exige autenticação para todos os endpoints neste controlador
    public class StudentController : ControllerBase
    {
        private readonly IStudentCRUD _studentCRUD;

        public StudentController(IStudentCRUD studentCRUD)
        {
            _studentCRUD = studentCRUD;

        }

        [HttpGet(Name = "GetStudent")]
        public IEnumerable<Student> Get()
        {
            return _studentCRUD.ReadAll();
        }

        [HttpPost(Name = "CreateStudent")]
        public void Post(StudentCreateDTO entity){
            Student student= new() {
                IdStudent= 0,
                Registration= entity.Registration,
                Bio = entity.Bio,
                Course= entity.Course,
                Email= entity.Email,
                Name= entity.Name,
                Skills= entity.Skills,
                User= new(){UserName= entity.User.UserName,Password = entity.User.Password, Rules= entity.User.Rules}
                };
            if( student.Skills != null){
                foreach (var skill in student.Skills)
                {
                    skill.IdSkill= 0;
                    skill.IdProject = null;
                } 
            }
            _studentCRUD.Create(student);
        }

        [HttpDelete(Name = "DeleteStudent")]
        public IActionResult Delete(Student entity)
        {
            var student = _studentCRUD.ReadById(entity.IdStudent);

            if (student == null)
            {
                return NotFound($"Student with Id {entity.IdStudent} not found.");
            }

            _studentCRUD.Delete(entity);
            return Ok($"Student with Id {entity.IdStudent} deleted successfully.");
        }
        
        [HttpPut(Name = "UpdateStudent")]
        public IActionResult Update(StudentUpdateDTO entity)
        {
            var student = _studentCRUD.ReadById(entity.IdStudent);

            if (student == null)
            {
                return NotFound($"Student with Id {entity.IdStudent} not found.");
            }
            Student studentToUpdate= new() {
                IdStudent= entity.IdStudent,
                Registration= entity.Registration,
                Bio = entity.Bio,
                Course= entity.Course,
                Email= entity.Email,
                Name= entity.Name,
                Skills= entity.Skills,
                User= new(){UserName= entity.User.UserName,Password = entity.User.Password, Rules= entity.User.Rules}
                };
            _studentCRUD.Update(studentToUpdate);
            return Ok($"Student with Id {entity.IdStudent} updated successfully.");
        }
    }

