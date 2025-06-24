using Microsoft.AspNetCore.Mvc;
using Stock.Models;
using Stock.Models.DTO;
using Stock.Services.Repositories;

namespace Stock.Api.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginService;

        public LoginController(ILoginRepository loginService)
        {
            _loginService = loginService;
        }
        [HttpGet("GetUsuarios")]
        public async Task<List<Login>> GetUsuarios()
        {
            return await Task.Run(() => _loginService.GetUsuarios());
        }
        [HttpPost("Login")]
        public async Task<LoginResultDTO>Login(LoginDTO login)
        {
            return await Task.Run(()=>_loginService.Login(login));
        }
    }
}
