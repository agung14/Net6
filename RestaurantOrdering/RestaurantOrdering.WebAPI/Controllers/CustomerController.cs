using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrdering.Model.Request;
using RestaurantOrdering.WebAPI.JwtService;

namespace RestaurantOrdering.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IConfiguration _config;

        public CustomerController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("reservetable")]
        public string GetRandomToken(CustomerRequest request)
        {
            var jwt = new JwtServices(_config);

            var token = jwt.GenerateJwt(request.TableCode!, request.Name!, request.Email!);

            return token;
        }

    }
}
