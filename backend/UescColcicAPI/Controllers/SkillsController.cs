using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http;

namespace UescColcicAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillCRUD _skillsCRUD;

        public SkillsController(ISkillCRUD skillsCRUD)
        {
            _skillsCRUD = skillsCRUD;
        }

       
        [HttpGet(Name = "GetSkills")]
        public IEnumerable<Skill> Get()
        {
            return _skillsCRUD.ReadAll();
        }

        [HttpPost(Name = "CreateSkill")]
        public void Post(Skill entity){
            _skillsCRUD.Create(entity);
        }

        [HttpDelete(Name = "DeleteSkill")]
        public void Delete(Skill entity){
            _skillsCRUD.Delete(entity);
        }
        
        [HttpPut(Name = "UpdateSkill")]
        public void Put(Skill entity){
            _skillsCRUD.Update(entity);
        }
    }
