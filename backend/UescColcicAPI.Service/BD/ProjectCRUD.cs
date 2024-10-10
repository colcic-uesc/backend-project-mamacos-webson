﻿﻿using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace UescColcicAPI.Services.BD;

public class ProjectCRUD : IProjectCRUD
{
    private UescColcicDBContext _context;
   public ProjectCRUD(UescColcicDBContext context){
        _context = context;
   }
    public void Create(Project entity)
    {   
        _context.Project.Add(entity);
        if (entity.Skills != null)
        {
            foreach (var skill in entity.Skills)
            {
                // 3. Separar e criar as skills associadas ao projeto
                skill.IdProject = entity.IdProject; // Relacionar skill ao projeto recém-criado
                _context.Add(skill);
            }
        }
        _context.SaveChanges();
    }

    public void Delete(Project entity)
    {   
        var Project = this.ReadById(entity.IdProject);
        if(Project is  not null){
            _context.Project.Remove(Project);

            _context.SaveChanges();
        }
    }

    public IEnumerable<Project> ReadAll()
    {
        return _context.Project;
    }

    public Project? ReadById(int id)
    {
        var Project = _context.Project.FirstOrDefault(p => p.IdProject == id);
        return Project;
    }

    public void Update(Project entity)
    {
        var Project = this.ReadById(entity.IdProject);
        if(Project is not null)
        {
            Project.IdProject = entity.IdProject;
            Project.ProjectTitle = entity.ProjectTitle;
            Project.ProjectDescription = entity.ProjectDescription;
            //Project.ProjectStartDate = entity.ProjectStartDate;
            //Project.ProjectEndDate = entity.ProjectEndDate;

            _context.SaveChanges();
        }
    }

    private Project? Find(int id)
    {
        return _context.Project.FirstOrDefault(x => x.IdProject == id);
    }

}