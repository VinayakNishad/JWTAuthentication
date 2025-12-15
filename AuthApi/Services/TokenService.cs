using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using AuthApi.Models;
namespace AuthApi.Services;

public class TokenService(IConfiguration config)
{
    private readonly IConfiguration _config = config;

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
{
new(ClaimTypes.NameIdentifier, user.Id.ToString()),
new(ClaimTypes.Email, user.Email)
};


        var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));


        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
        issuer: _config["Jwt:Issuer"],
        audience: _config["Jwt:Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(
        int.Parse(_config["Jwt:ExpiresInMinutes"]!)),
        signingCredentials: creds
        );


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}