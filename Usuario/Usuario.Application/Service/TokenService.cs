using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Usuario.Domain.Interface.Service;
using domain = Usuario.Domain.Entity;
namespace Usuario.Application.Service;

public class TokenService : ITokenService
{
    private string _secretKey;
   private readonly SigningCredentials _credentials;
    public TokenService(IConfiguration configuration)
    {
        _secretKey = configuration["Jwt:Secret"];
    }

    public string GerarToken(domain.Usuario usuario)
    {

        var key = _secretKey ?? throw new InvalidOperationException("Chave invalida");

        var rsa = RSA.Create();
        rsa.ImportFromPem(File.ReadAllText(key));
        var credentials = new SigningCredentials(new RsaSecurityKey(rsa),SecurityAlgorithms.RsaSha256);

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
