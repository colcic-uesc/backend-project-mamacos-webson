using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http;

namespace UescColcicAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillCRUD _skillCRUD;

        public SkillController(ISkillCRUD skillCRUD)
        {
            _skillCRUD = skillCRUD;
        }

       
        [HttpGet(Name = "GetSkill")]
        public IEnumerable<Skill> Get()
        {
            return _skillCRUD.ReadAll();
        }

        [HttpPost(Name = "CreateSkill")]
        public void Post(Skill entity){
            _skillCRUD.Create(entity);
        }

        [HttpDelete(Name = "DeleteSkill")]
        public void Delete(Skill entity){
            _skillCRUD.Delete(entity);
        }
        
        [HttpPut(Name = "UpdateSkill")]
        public void Put(Skill entity){
            _skillCRUD.Update(entity);
        }
    }
