using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        
        // Task<User?> GetUserByNameAsync(string userName);
        // Task<User?> GetUserBySurnameAsync(string userSurname);
        // Task<User?> GetUserByEmailAsync(string userEmail);
        // Task<User?> GetUserByPhoneIdAsync(int userPhoneId);
        // Task<User?> GetUserByPhoneNumberAsync(string userPhoneNumber);
        Task<User?> GetUserByIdAsync(int userId, CancellationToken cancellationToken);
        IQueryable<User> GetAllUsers();
        Task<User> AddUserAsync(User user, CancellationToken cancellationToken);
        Task<User?> UpdateUserAsync(User user, CancellationToken cancellationToken);
        Task<User?> DeleteUserAsync(User user, CancellationToken cancellationToken);
    }
}