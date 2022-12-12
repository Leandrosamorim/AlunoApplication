using Domain.AlunoNS;
using Domain.AlunoNS.Interfaces;
using Domain.Auth;
using Domain.Models.AlunoNS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AlunoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    { 
        public IConfiguration _configuration;
        private readonly IAlunoService _alunoService;

        public AuthController(IConfiguration configuration, IAlunoService alunoService)
        {
            _configuration = configuration;
            _alunoService = alunoService;
        }


        [HttpPost]
        public async Task<IActionResult> Post(LogarAlunoCommand cmd)
        {
            if (cmd == null)
                return BadRequest("Invalid User");
            else
            {
                var userData = await GetAluno(cmd);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
                if (userData != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                        new Claim("Id", userData.Id.ToString(), null),
                        new Claim("Username", userData.UserName ),
                        new Claim("Password", userData.Password)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                    return BadRequest("User not found");
            }
        }
        [HttpGet]
        public async Task<Aluno> GetAluno(LogarAlunoCommand cmd)
        {
            return _alunoService.Logar(cmd);
        }
    }
}
