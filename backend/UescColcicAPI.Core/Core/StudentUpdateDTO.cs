using BackEndAPI.Core;
using UescColcicAPI.Core;

namespace BackEndAPI.Core;

public class StudentUpdateDTO
{
    public int IdStudent { get; set; } 
    public string? Registration { get; set; } 
    public string? Name { get ; set; } 
    public string? Email { get; set; } 
    public string? Course { get; set; } 
    public string? Bio { get; set; } 
    public ICollection<Skill> Skills { get; set; } = null!;
    public UserCreateDTO User { get; set; } = null!;
}