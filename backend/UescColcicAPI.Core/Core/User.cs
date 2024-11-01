using System;

namespace UescColcicAPI.Core;

public class User
{
    public int IdUser { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Rules { get; set; }
    public Student? Student { get; set; }
}