/*
 * \file AccountController.cs
 * \brief API controller handling account
 *
 * The AccountController class defines endpoints related to account
 * such as creating, updating and deleting account. Retrieving user's accounts,
 * account balance, account summary and account data reports 
 *
 * Endpoints:
 * - GET /api/accounts/ – Retrieves all user accounts
 * - POST /api/accounts/ – Creates a new user account
 * - GET /api/accounts/{id} – Retrieves a specific user account by id
 * - PATCH /api/accounts/{id} – Update a user account
 * - DELETE /api/accounts/{id} – Delete a user account
 * - GET /api/accounts/{id}/balance – Retrieves the account's current balance
 * - GET /api/accounts/{id}/summary – Retrieves summary of inflows and outflows
 * - GET /api/accounts/{id}/report – Generates a PDF report of the account
 *
 * \date 17-09-2025
 */

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transacto.Application.Account.Commands.CreateAccount;
using Transacto.Application.Account.Commands.DeleteAccount;
using Transacto.Application.Account.Commands.UpdateAccount;
using Transacto.Application.Account.Queries.GetAccount;
using Transacto.Application.Account.Queries.GetAccountBalance;
using Transacto.Application.Account.Queries.GetAccountReport;
using Transacto.Application.Account.Queries.GetAccounts;
using Transacto.Application.Account.Queries.GetAccountSummary;

namespace Transacto.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAccounts()
    {
        var result = await mediator.Send(new GetAccountsQuery());
        return Ok(result);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand command)
    {
        await mediator.Send(command);
        return Created(string.Empty, null);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAccount([FromRoute] Guid id)
    {
        var result = await mediator.Send(new GetAccountQuery(id));
        return Ok(result);
    }
    
    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAccount([FromRoute] Guid id)
    {
        await mediator.Send(new UpdateAccountCommand(id));
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAccount([FromRoute] Guid id)
    {
        await mediator.Send(new DeleteAccountCommand(id));
        return NoContent();
    }
    
    [HttpGet("{id:guid}/balance")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAccountBalance(Guid id)
    {
        var result = await mediator.Send(new GetAccountBalanceQuery(id));
        return Ok(result);
    }
    
    [HttpGet("{id:guid}/summary")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAccountSummary(Guid id)
    {
        var result = await mediator.Send(new GetAccountSummaryQuery(id));
        return Ok(result);
    }
    
    [HttpGet("{id:guid}/report")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAccountReport(Guid id)
    {
        var file = await mediator.Send(new GetAccountReportQuery(id));
        return File(file, "application/pdf", $"account-{id}.pdf");
    }
}