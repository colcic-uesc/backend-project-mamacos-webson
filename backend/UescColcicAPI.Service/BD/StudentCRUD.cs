
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace UescColcicAPI.Services.BD;

public class StudentCRUD : IStudentCRUD
{
    private UescColcicDBContext _context;
    public StudentCRUD(UescColcicDBContext context){
        _context = context;
    }
    public void Create(Student entity)
    {   
        _context.Student.Add(entity);
        _context.SaveChanges();

    }

    public void Delete(Student entity)
    {   
        var Student = this.ReadById(entity.IdStudent);
        if(Student != null){
            _context.Student.Remove(Student);
            _context.SaveChanges();
        }
    }

   public IEnumerable<Student> ReadAll()
    {
        return _context.Student.Include(p => p.Skills).ToList();
    }

    public Student? ReadById(int id)
    {
        var Student = _context.Student.FirstOrDefault(p => p.IdStudent == id);
        return Student;
    }

    public void Update(Student entity)
    {
        var Student = this.ReadById(entity.IdStudent);
        if(Student is not null)
        {
            Student.IdStudent = entity.IdStudent;
            Student.Registration = entity.Registration;
            Student.Name = entity.Name;
            Student.Email = entity.Email;
            Student.Course = entity.Course;
            Student.Bio = entity.Bio;
        

            _context.SaveChanges();
        }
    }

}



