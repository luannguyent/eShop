using Identity.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Identity.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private IOptionsSnapshot<AudienceSetting> _setting;
        public AuthController(IOptionsSnapshot<AudienceSetting> setting)
        {
            _setting = setting;
        }

        [HttpGet]
        [Route("gettoken")]
        public ActionResult GetToken(string userName, string pwd)
        {
            if (userName == "luannguyen" && pwd == "LuanNguyen@456")
            {
                var now = DateTime.UtcNow;

                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64)
                };

                var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_setting.Value.Secret));
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = true,
                    ValidIssuer = _setting.Value.Iss,
                    ValidateAudience = true,
                    ValidAudience = _setting.Value.Aud,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true,

                };

                var jwt = new JwtSecurityToken(
                    issuer: _setting.Value.Iss,
                    audience: _setting.Value.Aud,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                var responseJson = new
                {
                    access_token = encodedJwt,
                    expires_in = (int)TimeSpan.FromMinutes(2).TotalSeconds
                };

                return Ok(responseJson);
            }
            else
            {
                return Ok("User is invalid");
            }
        }
    }
}
