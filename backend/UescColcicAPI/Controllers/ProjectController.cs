using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http;

namespace UescColcicAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectCRUD _projectCRUD;

        public ProjectController(IProjectCRUD projectCRUD)
        {
            _projectCRUD = projectCRUD;

        }

        [HttpGet(Name = "GetProject")]
        public IEnumerable<Project> Get()
        {
            return _projectCRUD.ReadAll();
        }

        [HttpPost(Name = "CreateProject")]
        public void Post(Project entity){
            _projectCRUD.Create(entity);
        }

        [HttpDelete(Name = "DeleteProject")]
        public void Delete(Project entity){
            _projectCRUD.Delete(entity);
        }
        
        [HttpPut(Name = "UpdateProject")]
        public void Put(Project entity){
            _projectCRUD.Update(entity);
        }
    }
