/*
 * \file PdfGenerator.cs
 * \brief Service for generating pdf reports
 *
 * \date 17-09-2025
 */

using DinkToPdf;
using DinkToPdf.Contracts;
using Transacto.Application.Account.Interfaces;

namespace Transacto.Application.Account.Services;

public class PdfGenerator(IConverter converter) : IPdfGenerator
{
    public byte[] GenerateAccountExportPdf(string htmlContent)
    {
        var document = new HtmlToPdfDocument()
        {
            GlobalSettings = new GlobalSettings()
            {
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                DocumentTitle = "Account Report",
            },
            Objects =
            {
                new ObjectSettings()
                {
                    HtmlContent = htmlContent,
                    WebSettings = { DefaultEncoding = "utf-8" },
                }
            }
        };
        
        return converter.Convert(document);
    }
}