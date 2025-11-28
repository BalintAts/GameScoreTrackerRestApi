using GameScoreTrackerRestApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameScoreTrackerRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        //simulate logging in with registered user
        if (loginRequest.UserName != "username" || loginRequest.Password != "password")
        {
            return Content("Wrong username or password");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret secret secret secret secret secret secret"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, loginRequest.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: "somebody",
            audience: "thepeople",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: creds); 

        return Ok( new 
        { 
            token = new JwtSecurityTokenHandler().WriteToken(token) 
        });

    }
}
