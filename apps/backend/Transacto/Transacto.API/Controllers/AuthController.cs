/*
 * \file AuthController.cs
 * \brief API controller handling user authentication
 *
 * The AuthController class defines endpoints related to user
 * authentication such as registration, login and logout
 * 
 * Endpoints:
 * - POST /api/auth/register – Register a new user
 * - POST /api/auth/login – Authenticate an existing user
 * - POST /api/auth/logout – Log out the current user
 *
 * \date 15-09-2025
 * \updated 16-09-2025
 */

using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transacto.Application.Auth.Commands.DisableTwoFactor;
using Transacto.Application.Auth.Commands.EnableTwoFactor;
using Transacto.Application.Auth.Commands.Login;
using Transacto.Application.Auth.Commands.Register;

namespace Transacto.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success)
            return BadRequest(new { error = result.ErrorMessage });
        
        return Ok(new
        {
            userId = result.UserId,
            email = result.Email,
            token = result.Token
        });
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.Success)
            return BadRequest(new { error = result.ErrorMessage });
        
        Response.Cookies.Append("access_token", result.Token!, new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTime.UtcNow.AddMinutes(60)
        });
        
        return Ok(new
        {
            userId = result.UserId,
            email = result.Email,
            token = result.Token
        });
    }
    
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("access_token");
        return Ok(new { message = "Logged out" });
    }

    [HttpPost("twofactor/enable")]
    public async Task<IActionResult> EnableTwoFactorAuth()
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized();

        var secretKey = await mediator.Send(new EnableTwoFactorCommand(userId));
        return Ok(new
        {
            message = "Two-Factor Authentication enabled",
            secretKey
        });
    }
    
    [HttpPost("twofactor/disable")]
    public async Task<IActionResult> VerifyTwoFactorAuth()
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized();

        await mediator.Send(new DisableTwoFactorCommand(userId));
        return Ok(new
        {
            message = "Two-Factor Authentication disabled"
        });
    }
}