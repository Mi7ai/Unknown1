using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories
{
    public class UserRepository(ApplicationDataContext context) : IUserRepository
    {
        private readonly ApplicationDataContext _context = context;

        public async Task<User> AddUserAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }

        public async Task<User?> DeleteUserAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }

        public IQueryable<User> GetAllUsers()
        {
            //service layer must convert to list
            return _context.Users;
        }

        // public async Task<User?> GetUserByEmailAsync(string userEmail)
        // {
        //     return await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
        // }

        public async Task<User?> GetUserByIdAsync(int userId, CancellationToken cancellationToken)
        {
            return await _context.Users.FindAsync([userId], cancellationToken);
        }

        // public async Task<User?> GetUserByNameAsync(string userName)
        // {
        //     return await _context.Users.FirstOrDefaultAsync(u => u.Name == userName);
        // }

        // public async Task<User?> GetUserByPhoneIdAsync(int userPhoneId)
        // {
        //     return await _context.Users
        //         .Include(p => p.Phone)
        //         .FirstOrDefaultAsync(u => u.Phone != null && u.Phone.PhoneId == userPhoneId);
        // }

        // public async Task<User?> GetUserByPhoneNumberAsync(string userPhoneNumber)
        // {
        //     return await _context.Users
        //        .Include(p => p.Phone)
        //        .FirstOrDefaultAsync(u => u.Phone != null && u.Phone.Number == userPhoneNumber);
        // }

        // public async Task<User?> GetUserBySurnameAsync(string userSurname)
        // {
        //     return await _context.Users.FirstOrDefaultAsync(u => u.Surname == userSurname);
        // }

        public async Task<User?> UpdateUserAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}