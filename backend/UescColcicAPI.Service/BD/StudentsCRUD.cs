﻿using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace UescColcicAPI.Services.BD;

public class StudentsCRUD : IStudentsCRUD
{
    private UescColcicDBContext _context;
   public StudentsCRUD(UescColcicDBContext context){
        _context = context;
   }
    public void Create(Student entity)
    {
        _context.Students.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Student entity)
    {   
        var student = this.Find(entity.IdStudent);
        if(student is  not null){
            _context.Students.Remove(student);

            _context.SaveChanges();
        }
    }

    public IEnumerable<Student> ReadAll()
    {
        return _context.Students.Include(s => s.Skills);
    }

    public Student? ReadById(int id)
    {
        var student = this.Find(id);
        return student;
    }

    public void Update(Student entity)
    {
        var student = this.Find(entity.IdStudent);
        if(student is not null)
        {
            student.Registration = entity.Registration;
            student.Name = entity.Name;
            student.Email = entity.Email;
            student.Course = entity.Course;
            student.Bio = entity.Bio;
            student.Skill = entity.Skill;
            
            _context.SaveChanges();
        }
    }

    private Student? Find(int id)
    {
        return _context.Students.Include(s => s.Skills).FirstOrDefault(x => x.IdStudent == id);
    }

}