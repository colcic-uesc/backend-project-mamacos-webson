using System;

namespace UescColcicAPI.Services.Auth;
public interface ITokenGeneration
{
      public string GenerateJwtToken();
      
}
