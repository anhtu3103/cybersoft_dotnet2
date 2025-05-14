using AuthenticationService.DTOs;
using AuthenticationService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthServices _authServices;

        public AuthController(AuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegisterDTO registerDTO)
        {
            try
            {
                var response = await _authServices.Register(registerDTO);
                return Ok(response);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            } 
        }
    }
}
