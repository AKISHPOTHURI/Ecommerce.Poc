using Ecommerce.Api.Authentication;
using Ecommerce.Api.IService;
using Ecommerce.Api.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public IConfiguration _configuration { get; }
        public UserController(IUserService userService,IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Token([FromQuery] UserSellerLogin userSellerLogin)
        {
            try
            {
                var response = await _userService.Login(userSellerLogin);
                return Ok(response.Token);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }
    }
}
