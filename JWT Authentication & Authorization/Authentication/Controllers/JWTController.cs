using Authentication.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        public IConfiguration _Configuration;
        public readonly ApplicationDbcontext _context;
        public JWTController(IConfiguration Configuration, ApplicationDbcontext context)
        {
                _context = context;
            _Configuration = Configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserModel user)
        {
            if (user != null && user.UserName !=null && user.Password != null)
            {
                var userData = await Getuser(user.UserName, user.Password);
                var jwt = _Configuration.GetSection("Jwt").Get<Jwt>();
                if(user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("Id",user.userId.ToString()),
                        new Claim("UserName",user.UserName),
                        new Claim("Password",user.Password),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                    var signIn=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                    var token=new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires:DateTime.Now.AddMinutes(20),
                        signingCredentials:signIn);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }
        [HttpGet]
        public async Task<UserModel> Getuser(string username,string password)
        {
            return await _context.usermodel.FirstOrDefaultAsync(u=>u.UserName==username && u.Password==password);
        }
    }
}
