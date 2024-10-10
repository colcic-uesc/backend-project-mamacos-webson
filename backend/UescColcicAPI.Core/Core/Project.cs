using System;

namespace UescColcicAPI.Core;

public class Project
{
    public int IdProject { get; set; }
    public string? ProjectTitle { get; set; }
    public string? ProjectDescription { get; set; }
    public string? ProjectType { get; set; }
    //public int? ProjectStartDate {get; set;}
    //public int? ProjectEndDate { get; set; }
    public virtual ICollection<Skill>? Skills { get; set; } = null;

}