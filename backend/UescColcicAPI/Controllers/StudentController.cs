using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http;

namespace UescColcicAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
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
        public void Post(Student entity){
            entity.IdStudent = 0;
            if( entity.Skills != null){
                foreach (var skill in entity.Skills)
                {
                    skill.IdSkill= 0;
                    skill.IdProject = null;
                } 
            }
            _studentCRUD.Create(entity);
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
        public IActionResult Update(Student entity)
        {
            var student = _studentCRUD.ReadById(entity.IdStudent);

            if (student == null)
            {
                return NotFound($"Student with Id {entity.IdStudent} not found.");
            }
            _studentCRUD.Update(entity);
            return Ok($"Student with Id {entity.IdStudent} updated successfully.");
        }
    }

