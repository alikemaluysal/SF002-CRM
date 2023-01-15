using Company.Crm.Application.Dtos;
using Company.Crm.Application.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Company.Crm.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(LoginDto model)
    {
        if (String.IsNullOrEmpty(model.EmailAddressOrUsername) || String.IsNullOrEmpty(model.Password))
            return BadRequest("Invalid user");

        var user = _userService.Login(model);

        if (user != null)
        {
            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name + " " + user.Surname),
                    new Claim(ClaimTypes.GivenName, user.Name),
                    new Claim(ClaimTypes.Surname, user.Surname),
                    new Claim(ClaimTypes.Email, user.Email)
                };

            if (user.Roles.Any())
            {
                foreach (var role in user.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:Jwt:SecurityKey"]));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(1);
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Auth:Jwt:Issuer"],
                audience: _configuration["Auth:Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: signingCredentials
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new { accessToken, ExpireAt = expires });

        }

        return Unauthorized();
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerModel)
    {
        if (!String.IsNullOrEmpty(registerModel.EmailAddress))
            return BadRequest("User is exist!");

        var isUserExist = await _userService.IsUserExist(registerModel.EmailAddress, registerModel.EmailAddress);

        if (isUserExist)
            return BadRequest("User is exist!");

        var user = _userService.Register(registerModel);
        if (user != null)
        {
            user.Password = "";

            return Ok(user);
        }

        return BadRequest("User is exist!");
    }

}
