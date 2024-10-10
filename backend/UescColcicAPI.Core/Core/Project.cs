using System;

namespace UescColcicAPI.Core;

public class Project
{
    public int IdProject { get; set; }
    public string? ProjectTitle { get; set; }
    public string? ProjectDescription { get; set; }
    public string? ProjectType { get; set; }
    //public DateOnly? ProjectStartDate {get; set;}
    //public DateOnly? ProjectEndDate { get; set; }
}