using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

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

       
        [HttpGet(Name = "")]
        public IEnumerable<Skill> Get()
        {
            return _skillsCRUD.ReadAll();
        }

        [HttpPost(Name = "")]
        public void Post(Skill entity){
            _skillsCRUD.Create(entity);
        }

        [HttpDelete(Name = "")]
        public void Delete(Skill entity){
            _skillsCRUD.Delete(entity);
        }
        
        [HttpPut(Name = "")]
        public void Put(Skill entity){
            _skillsCRUD.Update(entity);
        }
    }
