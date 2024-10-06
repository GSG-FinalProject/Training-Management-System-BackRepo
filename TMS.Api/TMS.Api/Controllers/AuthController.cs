using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Api.Responses;
using TMS.Application.Abstracts.IAuthService;
using TMS.Domain.DTOs.Admin;
using TMS.Domain.DTOs.shared;
using TMS.Domain.DTOs.Trainee;
using TMS.Domain.DTOs.Trainer;
using TMS.Domain.Interfaces.ILogger;

namespace TMS.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IResponseHandler _responseHandler;
    private readonly ILog _log;
    private readonly IUserManager _userManager;
    private readonly ITokenService _tokenService;

    public AuthController(IAuthService authService, IResponseHandler responseHandler, ILog log, IUserManager userManager, ITokenService tokenService)
    {
        _authService = authService;
        _responseHandler = responseHandler;
        _log = log;
        _userManager = userManager;
        _tokenService = tokenService;
    }
    [HttpPost("register/admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminDto registerAdminDto)
    {
        try
        {
            var result = await _authService.RegisterAdminAsync(registerAdminDto);
            return _responseHandler.Success(result, "Admin registered successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest(ex.Message);
        }
    }


    [HttpPost("register/trainer")]
   // [Authorize(Roles ="Admin")]
    public async Task<IActionResult> RegisterTrainer([FromBody] RegisterTrainerDto registerTrainerDto)
    {
        try
        {
            var result = await _authService.RegisterTrainerAsync(registerTrainerDto);
            return _responseHandler.Success(result, "Trainer registered successfully.");
        }
        catch (DbUpdateException dbEx)
        {
            return _responseHandler.BadRequest($"Database error: {dbEx.InnerException?.Message ?? dbEx.Message}");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest(ex.Message);
        }
    }



    [HttpPost("register/trainee")]
   // [Authorize(Roles ="Admin")]
    public async Task<IActionResult> RegisterTrainee([FromBody] RegisterTraineeDto registerTraineeDto)
    {
        try
        {
            var result = await _authService.RegisterTraineeAsync(registerTraineeDto);
            return _responseHandler.Success(result, "Trainee registered successfully.");
        }
        catch (Exception ex)
        {
            return _responseHandler.BadRequest(ex.Message);
        }
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            return BadRequest("Invalid email or password.");
        }

        var token = _tokenService.GenerateToken(user);
        var response = new LoginResponseDto
        {
            Token = token,
            UserType = user.UserType,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };

        return _responseHandler.Success(response);
    }
}
