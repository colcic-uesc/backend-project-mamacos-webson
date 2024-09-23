using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;

namespace UescColcicAPI.Services.BD;
public class StudentsCRUD : IStudentsCRUD
{
    private static readonly List<Student> Students = new()
    {
            new Student
            {
                IdStudent = 1,
                Registration = "2023001",
                Name = "Douglas",
                Email = "douglas.cic@uesc.br",
                Course = "Computer Science",
                Bio = "Aspiring software developer with a passion for coding."
            },
            new Student
            {
                IdStudent = 2,
                Registration = "2023002",
                Name = "Estevão",
                Email = "estevao.cic@uesc.br",
                Course = "Computer Science",
                Bio = "Interested in AI and machine learning."
            },
            new Student
            {
                IdStudent = 3,
                Registration = "2023003",
                Name = "Gabriel",
                Email = "gabriel.cic@uesc.br",
                Course = "Information Systems",
                Bio = "Data enthusiast with experience in database management."
            },
            new Student
            {
                IdStudent = 4,
                Registration = "2023004",
                Name = "Gabriela",
                Email = "gabriela.cic@uesc.br",
                Course = "Software Engineering",
                Bio = "Focused on software development and cloud computing."
            }
    };

    public void Create(Student entity)
    {   
        entity.IdStudent =  Students.Count > 0 ? Students.Max(x => x.IdStudent) + 1 : 1; // autoincrement id
        Students.Add(entity); // add an object of type student in students list
    }
    public void Delete(Student entity)
    {
        // Get the ID of the student you want to delete
        int refStudentId = entity.IdStudent-1;

        // Search student in list with the id
        Student studentToRemove = Students.FirstOrDefault(studentInList => studentInList.IdStudent == refStudentId);

        // If the student is found, remove him
        if (studentToRemove != null)
        {
            Students.RemoveAt(refStudentId);
        }
    }

    public IEnumerable<Student> ReadAll()
    {
        return Students;
    }
    
    public void Update(Student entity)
    {
        int refStudentId = entity.IdStudent - 1;

        Student studentToUpdate = Students.FirstOrDefault(studentInList => studentInList.IdStudent == refStudentId);

        if(studentToUpdate != null){
            Students[refStudentId].Registration = entity.Registration;
            Students[refStudentId].Name = entity.Name;
            Students[refStudentId].Email = entity.Email;
            Students[refStudentId].Course = entity.Course;
            Students[refStudentId].Bio = entity.Bio;
        }
    }
}
