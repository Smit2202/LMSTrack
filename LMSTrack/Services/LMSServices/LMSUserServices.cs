using LMSTrack.Data;
using LMSTrack.Model;
using Microsoft.EntityFrameworkCore;
using static LMSTrack.Model.ModelClass;

namespace LMSTrack.Services.LMSServices
{
    public class LMSUserServices : ILMSUserServices
    {
        private readonly LMSDbContext _context;

        public LMSUserServices(LMSDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            var heroes = await _context.Users.ToListAsync();
            return heroes;
        }

        public async Task<User?> GetUser(int id)
        {
            var hero = await _context.Users.FindAsync(id);
            if (hero is null)
                return null;

            return hero;
        }

        public async Task<List<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Returning the list of books after adding the new book
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> PutUser(int id, User user)
        {
            var hero = await _context.Users.FindAsync(id);
            if (hero is null)
                return null;

            hero.Name = user.Name;
            hero.UserId = user.UserId;
            hero.PhoneNumber = user.PhoneNumber;
            hero.Email = user.Email;


            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }
        public async Task<List<User>> DeleteUser(int id)
        {
            var hero = await _context.Users.FindAsync(id);
            if (hero is null)
                return null;

            _context.Users.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }

        private bool USerExists(int userId)
        {
            return _context.Users.Any(e => e.UserId == userId);
        }
    }
}
