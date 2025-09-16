/*
 * \file UserController.cs
 * \brief API controller handling user
 *
 * The UserController class defines endpoints related to user
 * such as deactivating account, updating and receives information
 *
 * Endpoints:
 * - GET /api/user/me – Receives user's
 * - PATCH /api/user/me – Update user's details
 * - DELETE /api/user/me – Delete user's account
 *
 * \date 16-09-2025
 */

using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transacto.Application.User.Commands.DeleteUser;
using Transacto.Application.User.Commands.UpdateUser;
using Transacto.Application.User.Queries.GetUser;

namespace Transacto.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet("me")]
    public async Task<IActionResult> GetUser()
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized();

        var user = await mediator.Send(new GetUserQuery(userId));
        return Ok(user);
    }
    
    [HttpPatch("me")]
    public async Task<IActionResult> UpdateUserDetails([FromBody] UpdateUserCommand command)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized();
        
        await mediator.Send(new UpdateUserCommand(userId, command.Email, command.PasswordHash));
        return Ok();
    }
    
    [HttpDelete("me")]
    public async Task<IActionResult> DeleteUser()
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!Guid.TryParse(userIdClaim, out var userId))
            return Unauthorized();
        
        await mediator.Send(new DeleteUserCommand(userId));
        return NoContent();
    }
}