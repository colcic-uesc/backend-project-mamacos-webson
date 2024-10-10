using System;
using System.Text.Json.Serialization;

namespace UescColcicAPI.Core;

public class Skill
{

   public int IdSkill { get; set; }

   public string? Title { get; set; }
    [JsonIgnore]
   public string? Description { get; set; }
    [JsonIgnore]
   public int IdProject {  get; set;   }
    [JsonIgnore]
    public virtual Project? Project { get; set; }
}