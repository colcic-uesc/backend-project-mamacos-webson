using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD;
public class StudentsCRUD : IStudentsCRUD
{
    private readonly ISkillCRUD _skillsCRUD; // Inject dependecy

    public StudentsCRUD(ISkillCRUD skillsCRUD) // 
    {
        _skillsCRUD = skillsCRUD; // to acess readAll()
    }
    
    private static readonly List<Student> Students = new()
    {
            new Student
            {
                IdStudent = 1,
                Registration = "2023001",
                Name = "Douglas",
                Email = "douglas.cic@uesc.br",
                Course = "Computer Science",
                Bio = "Aspiring software developer with a passion for coding.",
                skills = new List<Skill>() // for each student a new list of skills
            },
            new Student
            {
                IdStudent = 2,
                Registration = "2023002",
                Name = "Estevão",
                Email = "estevao.cic@uesc.br",
                Course = "Computer Science",
                Bio = "Interested in AI and machine learning.",
                skills = new List<Skill>() // for each student a new list of skills
            },
            new Student
            {
                IdStudent = 3,
                Registration = "2023003",
                Name = "Gabriel",
                Email = "gabriel.cic@uesc.br",
                Course = "Information Systems",
                Bio = "Data enthusiast with experience in database management.",
                skills = new List<Skill>() // for each student a new list of skills
            },
            new Student
            {
                IdStudent = 4,
                Registration = "2023004",
                Name = "Gabriela",
                Email = "gabriela.cic@uesc.br",
                Course = "Software Engineering",
                Bio = "Focused on software development and cloud computing.",
                skills = new List<Skill>() // for each student a new list of skills
            }
    };
    public void Create(Student entity)
    {
        entity.IdStudent = Students.Count > 0 ? Students.Max(x => x.IdStudent) + 1 : 1; // autoincrement id
        var listSkillGlobal= _skillsCRUD.ReadAll();
        var listSkillRef = entity.skills;
        var skillsToAdd = new List<Skill>();

        foreach (var skill in listSkillRef)
        {
            var searchSkill = listSkillGlobal.FirstOrDefault((x)=>x.IdSkill == skill.IdSkill); // acess method GetSkillById

            if (searchSkill != null)
            {
                skillsToAdd.Add(searchSkill); // store in a temporary list to save skills valids
            }
        }
        entity.skills.Clear(); // clear trash in list 
        foreach (var skill in skillsToAdd)
        {
            entity.skills.Add(skill);// add valid skills
        }
        Students.Add(entity);// create student
    }


    public void Delete(Student entity)
    {
        // Get the ID of the student you want to delete
        int refStudentId = entity.IdStudent;

        // Search student in list with the id
        Student studentToRemove = Students.FirstOrDefault(studentInList => studentInList.IdStudent == refStudentId);

        // If the student is found, remove him
        if (studentToRemove != null)
        {
            Students.Remove(studentToRemove);
        }
    }

    public IEnumerable<Student> ReadAll()
    {
        return Students;
    }
    
    public void Update(Student entity)
    {
        int refStudentId = entity.IdStudent;
        Student studentToUpdate = Students.FirstOrDefault(studentInList => studentInList.IdStudent == refStudentId);
        List<Skill> skillsRef = entity.skills;
        var listSkillGlobal= _skillsCRUD.ReadAll();
        var skillsToUpdate = new List<Skill>();


        // exists student?
        if (studentToUpdate != null)
        {
            foreach (var skill in skillsRef)
            {
                var searchSkill = listSkillGlobal.FirstOrDefault(x => x.IdSkill == skill.IdSkill); // search validSkill
                if (searchSkill != null)
                {
                    Console.WriteLine(searchSkill);
                    skillsToUpdate.Add(searchSkill); // store in a temporary list to save skills valids
                }
            }

            studentToUpdate.skills.Clear(); // clear trash in list 
            foreach (var skill in skillsToUpdate)
            {
                studentToUpdate.skills.Add(skill);// add valid skills
            }

            // Updtading other attributes of student entity
            studentToUpdate.Registration = entity.Registration;
            studentToUpdate.Name = entity.Name;
            studentToUpdate.Email = entity.Email;
            studentToUpdate.Course = entity.Course;
            studentToUpdate.Bio = entity.Bio;
        }
    }
}