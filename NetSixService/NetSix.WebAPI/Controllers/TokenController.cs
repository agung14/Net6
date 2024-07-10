using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetSix.WebAPI.JwtService;

namespace NetSix.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("{MobilePhone}")]
        public string GetRandomToken(string MobilePhone)
        {
            var jwt = new JwtServices(_config);
            var token = jwt.GenerateJwt(MobilePhone);
            return token;
        }
    }
}
