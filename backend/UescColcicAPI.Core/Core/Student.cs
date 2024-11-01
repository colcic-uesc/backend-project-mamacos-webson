using System;

namespace UescColcicAPI.Core;

public class Student
{
    public int IdStudent { get; set; }
    public string? Registration { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Course { get; set; }
    public string? Bio { get; set; }
    public int? IdUser { get; set; }
    public virtual ICollection<Skill>? Skills { get; set; } = [];
    public User User { get; set; } = null!;

}