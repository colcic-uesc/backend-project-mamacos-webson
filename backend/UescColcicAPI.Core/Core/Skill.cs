using System;
using System.Text.Json.Serialization;

namespace UescColcicAPI.Core;

public class Skill
{

   public int IdSkill { get; set; }

   public string? Title { get; set; }
   public string? Description { get; set; }
   public int? IdProject {  get; set; }
   public int? IdStudent { get; set;}
}