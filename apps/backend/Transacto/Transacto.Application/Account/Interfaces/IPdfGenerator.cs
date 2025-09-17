/*
 * \file PdfGenerator.cs
 * \brief Interface for generating pdf reports
 *
 * \date 17-09-2025
 */

namespace Transacto.Application.Account.Interfaces;

public interface IPdfGenerator
{
    byte[] GenerateAccountExportPdf(string htmlContent);
}