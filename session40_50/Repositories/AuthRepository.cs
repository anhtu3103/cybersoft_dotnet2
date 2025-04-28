using Microsoft.EntityFrameworkCore;
using session40_50.Data;
using session40_50.Interfaces;
using session40_50.Models;

namespace session40_50.Repositories
{
    public class AuthRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<User?> GetUserByResetToken(string resetToken)
        {
            //var user = await _context.Users.FirstOrDefaultAsync(x => x.TokenResetPassword == resetToken);
            var user = await _context.Users.FindAsync(7);
            if (user == null)
            {
                return null;
            }

            //check token was exprired
            if (DateTime.Now > user.ExpiresTokenReset) 
            {
                return null;
            }

            return user;
        }

        public async Task<User?> GetUserByVerificationTokenAsync(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(p => p.VerificationToken == token);

            if (user == null)
            {
                return null;
            }

            user.IsEmailVerified = true;
            user.VerificationToken = null;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
