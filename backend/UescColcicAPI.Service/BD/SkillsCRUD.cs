using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Data;

namespace UescColcicAPI.Services.BD;

public class SkillsCRUD : ISkillCRUD
{
    private static readonly List<Skill> Skills = new()
    {
        new Skill { IdSkill = 1, Title = "Programming", Description = "Proficiency in C# and .NET development" },
        new Skill { IdSkill = 2, Title = "Database Management", Description = "Experience with SQL Server and PostgreSQL" },
        new Skill { IdSkill = 3, Title = "Web Development", Description = "Skilled in HTML, CSS, JavaScript, and React" },
        new Skill { IdSkill = 4, Title = "Mobile Development", Description = "Expertise in React Native and mobile app design" }
    };

    public void Create(Skill entity)
    {
        entity.IdSkill = Skills.Count > 0 ? Skills.Max(x => x.IdSkill) + 1 : 1;
        Skills.Add(entity);
    }
    public void Delete(Skill entity)
    {
        var refIdSkill = entity.IdSkill - 1;
        var searchSkill = Skills.FirstOrDefault(skillInList => skillInList.IdSkill == refIdSkill);

        if (searchSkill != null){
            Skills.RemoveAt(entity.IdSkill-1);
        }
    }
    public IEnumerable<Skill> ReadAll()
    {
        return Skills;
    }
    public void Update(Skill entity)
    {
        var refIdSkill = entity.IdSkill -1 ;
        var searchSkill = Skills.FirstOrDefault(skillInList => skillInList.IdSkill == refIdSkill);

        if (searchSkill != null){
            Skills[refIdSkill].Title = entity.Title;
            Skills[refIdSkill].Description = entity.Description;
        }
    }
}
