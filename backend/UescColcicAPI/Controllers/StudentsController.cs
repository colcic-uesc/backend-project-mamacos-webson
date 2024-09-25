using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsCRUD _studentsCRUD;

        public StudentsController(IStudentsCRUD studentsCRUD)
        {
            _studentsCRUD = studentsCRUD;
        }

       
        [HttpGet(Name = "GetStudents")]
        public IEnumerable<Student> Get()
        {
            return _studentsCRUD.ReadAll();
        }

        [HttpPost(Name = "PostStudent")]
        public void Post(Student entity){
            _studentsCRUD.Create(entity);
        }

        [HttpDelete(Name = "DeleteStudent")]
        public void Delete(Student entity){
            _studentsCRUD.Delete(entity);
        }
        
        [HttpPut(Name = "UpdateStudent")]
        public void Put(Student entity){
            _studentsCRUD.Update(entity);
        }
    }
