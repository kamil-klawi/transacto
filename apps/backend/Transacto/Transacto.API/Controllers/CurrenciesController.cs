/*
 * \file CurrenciesController.cs
 * \brief API controller for managing currencies
 *
 * The CurrenciesController class defines endpoints related to currencies
 * such as retrieving a list of all currencies and exchange rates. Updating
 * the exchange rate of a currency
 *
 * Endpoints:
 * - GET /api/currencies – Retrieves all currencies
 * - GET /api/currencies/rates – Retrieves exchange rates for a base currency
 * - PATCH /api/currencies/rates – Updates the exchange rate of a currency
 *
 * \date 18-09-2025
 */

using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Transacto.Application.Currency.Commands.UpdateCurrencyRate;
using Transacto.Application.Currency.Exceptions;
using Transacto.Application.Currency.Queries.GetCurrencies;
using Transacto.Application.Currency.Queries.GetCurrenciesRates;

namespace Transacto.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurrenciesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCurrencies()
    {
        try
        {
            var result = await mediator.Send(new GetCurrenciesQuery());
            return Ok(result);
        }
        catch (CurrencyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("rates")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCurrenciesRates([FromBody] string baseCurrencyCode)
    {
        try
        {
            var result = await mediator.Send(new GetCurrenciesRatesQuery(baseCurrencyCode));
            return Ok(result);
        } catch (CurrencyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPatch("rates")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCurrencyRate([FromBody] UpdateCurrencyRateCommand command)
    {
        try
        {
            await mediator.Send(command);
            return Ok();
        }
        catch (CurrencyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}