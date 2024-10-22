using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace UescColcicAPI.Services.BD;

public class SkillCRUD : ISkillCRUD
{
    private UescColcicDBContext _context;
   public SkillCRUD(UescColcicDBContext context){
        _context = context;
   }
    public void Create(Skill entity)
    {
        
        _context.Skill.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Skill entity)
    {   
        var Skill = this.ReadById(entity.IdSkill);
        if(Skill is  not null){
            _context.Skill.Remove(Skill);

            _context.SaveChanges();
        }
    }

    public IEnumerable<Skill> ReadAll()
    {
        return _context.Skill;
    }

    public Skill? ReadById(int id)
    {
        var Skill = _context.Skill.FirstOrDefault(p => p.IdSkill == id);
        return Skill;
    }

    public void Update(Skill entity)
    {
        var Skill = this.ReadById(entity.IdSkill);
        if(Skill is not null)
        {
            Skill.IdSkill = entity.IdSkill;
            Skill.Title = entity.Title;
            Skill.Description = entity.Description;
            _context.SaveChanges();
        }
    }

}



