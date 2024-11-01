using BackEndAPI.Core;

namespace BackEndAPI.Core;

public class UserCreateDTO
{
    public string? UserName { get; set; } 
    public string? Password { get ; set; } 
    public string? Rules { get; set; } 
    
}