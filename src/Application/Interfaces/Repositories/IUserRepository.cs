using Domain.Entities;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int userId, CancellationToken cancellationToken);
        IQueryable<User> GetAllUsers();
        Task<User> AddUserAsync(User user, CancellationToken cancellationToken);
        Task<User?> UpdateUserAsync(User user, CancellationToken cancellationToken);
        Task<User?> DeleteUserAsync(User user, CancellationToken cancellationToken);
    }
}