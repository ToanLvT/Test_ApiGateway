using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace QLKHO.Authentication.Models
{
    public class AuthModel
    {
        public long code { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? jwtToken { get; set; }
        public string? Role { get; set; }

        public string GetToken(AuthModel userdata)
        {
            int expiredInMinutes = 4 * 60;
            var token = "";
            try
            {
                // create token
                var SessionId = Guid.NewGuid().ToString();
                // generate token string
                token = GenerateJwtToken(SessionId, userdata, expiredInMinutes);
                return token;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GenerateJwtToken(string sessionId, AuthModel user, int expireMinutes = 180)
        {
            string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
            const string SESSION_ID = "session_id";
            string USER_ID = "user_id";
            string USER_NAME = "username";
            string PASSWORD = "password";
            string ROLE = "Role";
            try
            {
                var now = DateTime.UtcNow;

                // generate jwt token
                var symmetricKey = Convert.FromBase64String(Secret);
                var tokenHandler = new JwtSecurityTokenHandler();
                var claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(SESSION_ID,sessionId),
                    new Claim(USER_ID, user.code.ToString()),
                    new Claim(USER_NAME, user.username),
                    new Claim(PASSWORD, user.password),
                    new Claim(ROLE, user.Role.ToString()),
                });

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claimsIdentity,
                    Expires = now.AddMinutes(expireMinutes),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
                };

                SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
                string token = tokenHandler.WriteToken(securityToken);
                return token;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}
