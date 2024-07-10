using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetSix.WebAPI.JwtService
{
    public class JwtServices
    {
        private readonly string _secret;
        private readonly string _expDate;

        public JwtServices(IConfiguration config)
        {
            _secret = config.GetSection("JwtConfig").GetSection("Key").Value!;
            _expDate = config.GetSection("JwtConfig").GetSection("Expired").Value!;
        }

        public string GenerateJwt(string MobilePhone)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, MobilePhone)
                }),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expDate)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
