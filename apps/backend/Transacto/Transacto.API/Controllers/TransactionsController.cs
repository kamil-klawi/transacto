/*
 * \file TransactionsController.cs
 * \brief API controller handling transactions
 *
 * The TransactionsController class defines endpoints related to transactions
 * such as creating a transaction. Retrieving all transaction history and account specific
 * transaction history
 *
 * Endpoints:
 * - POST /api/transactions/transfer – Creates a new transaction
 * - GET /api/transactions/history – Retrieves all transactions
 * - GET /api/transactions/history/{accountId} – Retrieves transaction history for a specific by account
 * - GET /api/transactions/{id} – Retrieves details of a specific transaction by id
 * - GET /api/transactions/schedule – Create a new schedule transaction
 * - GET /api/transactions/scheduled– Retrieves all scheduled transactions
 * - DELETE /api/transactions/scheduled/{id} – Cancels scheduled transaction by id
 *
 * \date 20-09-2025
 */

using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transacto.Application.Transaction.Commands.CancelScheduledTransaction;
using Transacto.Application.Transaction.Commands.CreateScheduledTransaction;
using Transacto.Application.Transaction.Commands.CreateTransaction;
using Transacto.Application.Transaction.Exceptions;
using Transacto.Application.Transaction.Queries.FindAllScheduledTransactions;
using Transacto.Application.Transaction.Queries.FindAllTransactions;
using Transacto.Application.Transaction.Queries.FindTransactionByAccountId;
using Transacto.Application.Transaction.Queries.FindTransactionById;

namespace Transacto.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController(IMediator mediator) : ControllerBase
{
    [HttpPost("/transfer")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateTransfer([FromBody] CreateTransactionCommand command)
    {
        try
        {
            await mediator.Send(command);
            return Created();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (TransactionNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("history")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFullHistory()
    {
        try
        {
            var results = await mediator.Send(new FindAllTransactionsQuery());
            return Ok(results);
        }
        catch (TransactionNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("history/{accountId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAccountHistory([FromRoute] Guid accountId)
    {
        try
        {
            var results = await mediator.Send(new FindTransactionByAccountIdQuery(accountId));
            return Ok(results);
        }
        catch (TransactionNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTransactionDetails([FromRoute] Guid id)
    {
        try
        {
            var result = await mediator.Send(new FindTransactionByIdQuery(id));
            return Ok(result);
        }
        catch (TransactionNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPost("schedule")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateScheduleTransaction([FromBody] CreateScheduledTransactionCommand command)
    {
        try
        {
            await mediator.Send(command);
            return Created();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (TransactionNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("scheduled")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetScheduledTransactions()
    {
        try
        {
            var results = await mediator.Send(new FindAllScheduledTransactionsQuery());
            return Ok(results);
        }
        catch (TransactionNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpDelete("scheduled/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteScheduledTransaction([FromRoute] Guid id)
    {
        try
        {
            await mediator.Send(new CancelScheduledTransactionCommand(id));
            return NoContent();
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (TransactionNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}