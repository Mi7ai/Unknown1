using Application.DTOs;
using Application.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService, IMapper mapper) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var result = await _userService.GetAllUsersAsync(cancellationToken);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId, CancellationToken cancellationToken)
        {
            var result = await _userService.GetUserByIdAsync(userId, cancellationToken);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return Ok(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] UserPostPutDto userDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _userService.AddUserAsync(userDto, cancellationToken);
            if (!result.Success || result.Data == null)
            {
                return BadRequest(result.Message ?? "User creation failed");
            }
            return CreatedAtAction(nameof(GetUserById),controllerName: "Users", new { userId = result.Data.UserId }, result.Data);
            
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUserAsync(int userId, [FromBody] UserPostPutDto userDto, CancellationToken cancellationToken)
        {
            var result = await _userService.UpdateUserAsync(userId, userDto, cancellationToken);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUserAsync(int userId, CancellationToken cancellationToken)
        {
            var result = await _userService.DeleteUserAsync(userId, cancellationToken);
            if (!result.Success)
            {
                return NotFound(result.Message);
            }
            return NoContent();
        }
    }
}