using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using EstudosAPI.Model;
using System.IdentityModel.Tokens.Jwt;

namespace EstudosAPI.Services
{
    public class TokenService : ITokenService
    {
        public object GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(Key.Secret);
            var TokenConfig = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(TokenConfig);
            var tokenString =  tokenHandler.WriteToken(token);

            return new
            {
                token = tokenString,
            };
        }

    }

    public interface ITokenService
    {
         public object GenerateToken(User user);
    }
}
