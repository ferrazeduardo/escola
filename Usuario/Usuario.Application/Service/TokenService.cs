using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Usuario.Domain.Interface.Service;
using domain = Usuario.Domain.Entity;
namespace Usuario.Application.Service;

public  class TokenService : ITokenService
{
    private string _secretKey;

    public TokenService(IConfiguration configuration)
    {
        _secretKey  = configuration["Jwt:Secret"];
    }

    public  string GerarToken(domain.Usuario usuario)
    {
        
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_secretKey));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("userId", usuario.Id.ToString()),
            new Claim("email", usuario.DS_EMAIL),
            new Claim(JwtRegisteredClaimNames.Iss, "escola_key")
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler()
            .WriteToken(token);
    }
}
