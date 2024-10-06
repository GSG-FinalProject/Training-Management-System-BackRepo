using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TMS.Api.Responses;
using TMS.Domain.Entities;

namespace TMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IResponseHandler _responseHandler;
    public UsersController(UserManager<User> userManager,IResponseHandler responseHandler)
    {
        _userManager = userManager;
        _responseHandler= responseHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            var users = await _userManager.Users.Select(u => new
            {
                u.Id,
                u.Email,
                u.UserName,
                u.UserType
            }).ToListAsync();

            return _responseHandler.Success(users, "Users retrieved successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest($"Failed to retrieve users: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user is null)
            {
                return _responseHandler.NotFound("User not found.");
            }

            var userData = new
            {
                user.Id,
                user.Email,
                user.UserName,
                user.UserType
            };

            return _responseHandler.Success(userData, "User retrieved successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest($"Failed to retrieve user: {ex.Message}");
        }
    }

    [HttpGet("get-user-id-from-token")]
    [Authorize] 
    public IActionResult GetUserIdFromToken()
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
            {
                return _responseHandler.BadRequest("Failed to retrieve user ID from token.");
            }

            return _responseHandler.Success(userId, "User ID retrieved successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest($"Error: {ex.Message}");
        }
    }


}
