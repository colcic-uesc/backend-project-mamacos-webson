
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UescColcicAPI.Services.Auth;

public class TokenGeneration : ITokenGeneration
{
     public string GenerateJwtToken()
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, "user"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("O ar está ficando mais quente ao seu redor"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "colcic.uesc.br",
            audience: "colcic.uesc.br",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
