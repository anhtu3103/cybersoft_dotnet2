using AuthenticationService.Data;
using AuthenticationService.DTOs;
using AuthenticationService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Services
{
    public class AuthServices
    {
        private readonly AuthDbContext _context;
        private readonly IConfiguration _configuration;
        //private readonly IHttpClientFactory _httpClientFactory; //option dành cho microService

        private readonly KafkaProducerService _kafkaProducerService;

        public AuthServices(AuthDbContext context, IConfiguration configuration, KafkaProducerService kafkaProducerService) //IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _configuration = configuration;
            //_httpClientFactory = httpClientFactory;
            _kafkaProducerService = kafkaProducerService;
        }

        public async Task<AuthResponse> Register(RegisterDTO registerDTO)
        {
            var checkEmailExist = await _context.Users.AnyAsync(u => u.Email == registerDTO.Email);

            if(checkEmailExist)
            {
                throw new Exception("Email already exist");
            }

            var user = new User
            {
                Email = registerDTO.Email,
                Username = registerDTO.Username,
                PasswordHash = registerDTO.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            //send email welcome -> call API Email Service
            //var client = _httpClientFactory.CreateClient("EmailService");
            //await client.PostAsJsonAsync("api/Email/Welcome", new
            //{
            //    email= user.Email,
            //    userName = user.Username
            //});    


            //using Kafka producer
            await _kafkaProducerService.PublicUserRegisteredEvent(user.Email, user.Username);

            return new AuthResponse
            {
                Token = "Test",
                Username = user.Username,
                Email = user.Email
            };
        }
    }
}
