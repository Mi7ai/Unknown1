using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        
        // Task<User?> GetUserByNameAsync(string userName);
        // Task<User?> GetUserBySurnameAsync(string userSurname);
        // Task<User?> GetUserByEmailAsync(string userEmail);
        // Task<User?> GetUserByPhoneIdAsync(int userPhoneId);
        // Task<User?> GetUserByPhoneNumberAsync(string userPhoneNumber);
        Task<User?> GetUserByIdAsync(int userId);
        IQueryable<User> GetAllUsers();
        Task<User> AddUserAsync(User user);
        Task<User?> UpdateUserAsync(User user);
        Task<User?> DeleteUserAsync(User user);
    }
}