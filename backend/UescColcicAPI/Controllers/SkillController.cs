using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace UescColcicAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]  // Exige autenticação para todos os endpoints neste controlador
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
            entity.IdSkill = 0;
            _skillCRUD.Create(entity);
        }

        [HttpDelete(Name = "DeleteSkill")]
        public IActionResult Delete(Skill entity)
        {
            var skill = _skillCRUD.ReadById(entity.IdSkill);

            if (skill == null)
            {
                return NotFound($"Skill with Id {entity.IdSkill} not found.");
            }

            _skillCRUD.Delete(entity);
            return Ok($"Skill with Id {entity.IdSkill} deleted successfully.");
        }
        
        [HttpPut(Name = "UpdateSkill")]
        public IActionResult Update(Skill entity)
        {
            var skill = _skillCRUD.ReadById(entity.IdSkill);

            if (skill == null)
            {
                return NotFound($"Skill with Id {entity.IdSkill} not found.");
            }
            _skillCRUD.Update(entity);
            return Ok($"Skill with Id {entity.IdSkill} updated successfully.");
        }
    }

