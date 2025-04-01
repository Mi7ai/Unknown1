using Application.Common.Models;
using Application.DTOs;
using System.Threading;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result<UserDto>> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default);
        Task<Result<List<UserDto>>> GetAllUsersAsync(CancellationToken cancellationToken = default);
        Task<Result<UserDto>> AddUserAsync(UserPostPutDto userDto, CancellationToken cancellationToken = default);
        Task<Result<UserDto>> UpdateUserAsync(int userId, UserPostPutDto userDto, CancellationToken cancellationToken = default);
        Task<Result<UserDto>> DeleteUserAsync(int userId, CancellationToken cancellationToken = default);
    }
}