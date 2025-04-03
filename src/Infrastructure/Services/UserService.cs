using Application.Common.Models;
using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }
        public async Task<Result<UserDto>> AddUserAsync(UserPostPutDto userDto, CancellationToken cancellationToken = default)
        {
            // Check payload
            if (userDto == null)
            {
                return Result<UserDto>.Fail("User data is null.");
            }

            // Check PhoneDto is present
            if (userDto.Phone == null)
            {
                return Result<UserDto>.Fail("Phone information is required.");
            }

            try
            {
                var user = _mapper.Map<User>(userDto);
                user.Phone = _mapper.Map<Phone>(userDto.Phone);

                await _userRepository.AddUserAsync(user, cancellationToken);
                return Result<UserDto>.Ok(_mapper.Map<UserDto>(user));
            }
            catch (Exception ex)
            {
                // Optional: Log the exception here
                return Result<UserDto>.Fail($"Failed to add user: {ex.Message}");
            }
        }

        public async Task<Result<UserDto>> DeleteUserAsync(int userId, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
            if (user == null)
            {
                return Result<UserDto>.Fail("User not found.");
            }
            await _userRepository.DeleteUserAsync(user, cancellationToken);
            return Result<UserDto>.Ok(_mapper.Map<UserDto>(user));
        }

        public async Task<Result<List<UserDto>>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            var query = _userRepository.GetAllUsers();
            var users = await query.ToListAsync(cancellationToken);
            return Result<List<UserDto>>.Ok(_mapper.Map<List<UserDto>>(users));
        }

        public async Task<Result<UserDto>> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
            if (user == null)
            {
                return Result<UserDto>.Fail("User not found.");
            }
            return Result<UserDto>.Ok(_mapper.Map<UserDto>(user));
        }

        public async Task<Result<UserDto>> UpdateUserAsync(int userId, UserPostPutDto userDto, CancellationToken cancellationToken = default)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
            if (existingUser == null)
            {
                return Result<UserDto>.Fail("User not found.");
            }
            _mapper.Map(userDto, existingUser);

            if (existingUser.Phone != null)
            {
                _mapper.Map(userDto.Phone, existingUser.Phone);
            }
            else
            {
                existingUser.Phone = _mapper.Map<Phone>(userDto.Phone);
            }

            await _userRepository.UpdateUserAsync(existingUser, cancellationToken);
            return Result<UserDto>.Ok(_mapper.Map<UserDto>(existingUser));
        }
    }
}