using Microsoft.AspNetCore.Mvc;
using session40_50.Interfaces;
using session40_50.Models;
using session40_50.Models.DTOs;

namespace session40_50.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserDTO user)
        {
            try
            {
                var result = await _userService.CreateUserAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("verify-email")]
        public async Task<ActionResult> VerifyEmail([FromQuery] string token)
        {
            try
            {
                var result = await _userService.VerifyEmailAsync(token);
                if (result != null)
                {
                    return Ok("Email verify successfully");
                }
                return BadRequest("Invalid token");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var result = await _userService.LoginAsync(loginDTO);
                if (result == null)
                {
                    return NotFound(new
                    {
                        message = "Email not valid"
                    });
                }

                return Ok(result);

                //if (result.Result == "")
                //{
                //    return BadRequest(new
                //    {
                //        message = "Password not valid"
                //    });
                //}

                //if (result.Result == "Email Not Verify")
                //{
                //    return BadRequest(new
                //    {
                //        message = "Email Not Verify"
                //    });
                //}

            }
            catch (Exception ex) 
            { 
                return BadRequest($"Failed to login {ex.Message}");
            }
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPassDTO forgotPassDTO)
        {
            try
            {
                var result = await _userService.ForgotPassword(forgotPassDTO.Email);
                if (result == null)
                {
                    return BadRequest("Invalid email");
                }

                return Ok("Password reset link sent to your email");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult?> ResetPassword([FromBody] ResetPassDTO resetPassDTO)
        {
            try
            {
                if (resetPassDTO.NewPassword != resetPassDTO.ConfirmNewPassword)
                {
                    return BadRequest("New password and confirm new password do not match");
                }

                var result = _userService.ResetPassword(resetPassDTO);
                if(result == null)
                    return BadRequest("Reset token does not exist or expired");
                return Ok("Reset password successs");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
