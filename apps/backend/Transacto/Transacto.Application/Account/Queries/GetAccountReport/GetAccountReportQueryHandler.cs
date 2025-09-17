/*
 * \file GetAccountReportQueryHandler.cs
 * \brief Query handler for retrieving a PDF report of the account
 *
 * \date 17-09-2025
 */

using MediatR;
using Microsoft.Extensions.Logging;
using Transacto.Application.Account.Services;
using Transacto.Domain.Account.Repositories;

namespace Transacto.Application.Account.Queries.GetAccountReport;

public class GetAccountReportQueryHandler(
    ILogger logger,
    IAccountRepository accountRepository,
    PdfGenerator pdfGenerator
    ) : IRequestHandler<GetAccountReportQuery, byte[]>
{
    public async Task<byte[]> Handle(GetAccountReportQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Retrieving account report data");
        var account = await accountRepository.GetAccount(request.Id);
        if (account == null)
            throw new ArgumentException("Account not found");
        
        var html = $"""
                        <h1>Account Report</h1>
                        <p><strong>Name:</strong> {account.Name}</p>
                        <p><strong>Type:</strong> {account.Type}</p>
                        <p><strong>Balance:</strong> {account.Balance.Amount} {account.Balance.CurrencyCode}</p>
                        <p><strong>Created:</strong> {account.CreatedAt:D}</p>
                    """;

        return pdfGenerator.GenerateAccountExportPdf(html);
    }
}