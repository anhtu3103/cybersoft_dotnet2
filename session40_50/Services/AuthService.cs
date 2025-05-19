using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using session40_50.Interfaces;
using session40_50.Models;
using session40_50.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace session40_50.Services
{
    public class AuthService: IUserService
    {
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IEmailService emailService, IConfiguration configuration)
        {
            _emailService = emailService;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<User> CreateUserAsync(UserDTO user)
        {
            //check user already exist

            //encryption password
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            //create token to verify new account
            var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            //create link verify new account
            //This link is API to verify new accouut
            var baseUrl = _configuration["AppSettings:BaseUrl"];
            var verifyUrl = $"{baseUrl}/verify-email?token={token}";

            //create new user
            var newUser = new User
            {
                Email = user.Email,
                Password =  user.Password,
                Name = user.Name,
                VerificationToken=token,
                IsEmailVerified=false, //default is false cause when create new user is not verify email
                Role = user.Role
            };

            await _userRepository.CreateUserAsync(newUser);

            //send email to new user
            var emailBody = $@"
                <h1>Welcome to our website</h1>
                <p>You have successfully registered to our website. </p>
                <p>Your username is: {user.Email}</p>
                <a href='{verifyUrl}'>Verify your email</a>
            ";

            await _emailService.SendEmailAsync(user.Email, "Welcome", emailBody);
            return newUser;
        }

        //define function generate token
        private string GenerateJwtToken(User user)
        {
            //get key create token from appsetting.json
            var securityKey = _configuration["Jwt:Key"];
            var formatKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var credential = new SigningCredentials(formatKey, SecurityAlgorithms.HmacSha256);

            //create claim (lưu thông tin cơ bản của uer để BE verify)
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role) //infor về role vào claim
            };

            //create token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credential
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string?> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            //checking password
            if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password)) // function have 2 params, first is password not encrypt and second is password encrypted, return true or false
            {
                throw new Exception("Password incorrect");
            }

            //checking email was verified
            if (!user.IsEmailVerified)
            {
                throw new Exception("Email Not Verify");;
            }
            var token = GenerateJwtToken(user);

            return token;
        }

        public async Task<User?> VerifyEmailAsync(string token)
        {
            return await _userRepository.GetUserByVerificationTokenAsync(token);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user;
        }

        public async Task<User?> ForgotPassword(string email)
        {
            var user = await GetUserByEmailAsync(email);
            if (user == null)
            {
                return null;
            }
 
            var tokenResetPassword = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            //save information reset token to db
            user.TokenResetPassword = tokenResetPassword;
            user.ExpiresTokenReset = DateTime.Now.AddHours(1);

            await _userRepository.UpdateUserAsync(user);

            //send email to user
            var emailBody = $@"
                <h1>Your account request to reset password</h1>
                <p>Your token is: {tokenResetPassword} </p>
            ";

            await _emailService.SendEmailAsync(email, "Reset Password", emailBody);

            return user;
        }

        public async Task<User?> ResetPassword(ResetPassDTO resetPassDTO)
        {
            var user = await _userRepository.GetUserByResetToken(resetPassDTO.ResetToken);
            if (user == null)
            {
                return null;
            }

            //encrypt new password
            user.Password = BCrypt.Net.BCrypt.HashPassword(resetPassDTO.NewPassword);
            user.TokenResetPassword = "";
            //user.ExpiresTokenReset = DateTime.null;

            await _userRepository.UpdateUserAsync(user);
            return user;
        }
    }
}
