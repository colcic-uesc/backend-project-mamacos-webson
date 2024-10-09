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
        var skill = this.Find(entity.IdSkill);
        if(skill is  not null){
            _context.Skill.Remove(skill);

            _context.SaveChanges();
        }
    }

    public IEnumerable<Skill> ReadAll()
    {
        return _context.Skill.Include(s => s.IdSkill);
    }

    public Skill? ReadById(int id)
    {
        var skill = this.Find(id);
        return skill;
    }

    public void Update(Skill entity)
    {
        var skill = this.Find(entity.IdSkill);
        if(skill is not null)
        {
            skill.Title = entity.Title;
            skill.Description = entity.Description;
            _context.SaveChanges();
        }
    }

    private Skill? Find(int id)
    {
        return _context.Skill.Include(s => s.IdSkill).FirstOrDefault(x => x.IdSkill == id);
    }

}