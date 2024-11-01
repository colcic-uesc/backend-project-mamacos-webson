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
            entity.IdProject = 0;
            if(entity.Skills != null){
                foreach (var skill in entity.Skills)
                {
                    skill.IdSkill= 0;
                    skill.IdStudent = null;
                } 
            }
            _projectCRUD.Create(entity);
        }

        [HttpDelete(Name = "DeleteProject")]
        public IActionResult Delete(Project entity)
        {
            var project = _projectCRUD.ReadById(entity.IdProject);

            if (project == null)
            {
                return NotFound($"Project with Id {entity.IdProject} not found.");
            }

            _projectCRUD.Delete(entity);
            return Ok($"Project with Id {entity.IdProject} deleted successfully.");
        }
        
        [HttpPut(Name = "UpdateProject")]
        public IActionResult Update(Project entity)
        {
            var project = _projectCRUD.ReadById(entity.IdProject);

            if (project == null)
            {
                return NotFound($"Project with Id {entity.IdProject} not found.");
            }
            _projectCRUD.Update(entity);
            return Ok($"Project with Id {entity.IdProject} updated successfully.");
        }
    }

