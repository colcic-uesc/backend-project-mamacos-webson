using System;

namespace UescColcicAPI.Core;

public class Skill
{

   public int IdSkill { get; set; }

   public string? Title { get; set; }

   public string? Description { get; set; }

   public virtual Project? Project { get; set; }

}