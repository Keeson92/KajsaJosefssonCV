using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using System;
using System.Diagnostics;
using KajsaJosefssonCV.ViewModels;

namespace KajsaJosefssonCV.Services
{
    public class PdfService
    {
        public void CreatePdf(MainViewModel viewModel)
        {
            try
            {
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Mitt CV";

                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                XFont fontTitle = new XFont("Verdana", 20, XFontStyle.Bold);
                XFont fontHeader = new XFont("Verdana", 14, XFontStyle.Bold);
                XFont fontNormal = new XFont("Verdana", 12, XFontStyle.Regular);

                double yPoint = 40;

                // Header
                gfx.DrawString(viewModel.HeaderName, fontTitle, XBrushes.Black, new XRect(40, yPoint, page.Width - 80, 40), XStringFormats.TopLeft);
                yPoint += 30;
                gfx.DrawString(viewModel.HeaderTitle, fontNormal, XBrushes.Black, new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                yPoint += 25;
                gfx.DrawString(viewModel.HeaderEmail, fontNormal, XBrushes.Black, new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                yPoint += 20;
                gfx.DrawString(viewModel.HeaderPhone, fontNormal, XBrushes.Black, new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                yPoint += 40;

                // Lägg till innehållet från Tabs
                foreach (var tab in viewModel.Tabs)
                {
                    gfx.DrawString(tab.TabHeader, fontHeader, XBrushes.DarkBlue, new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                    yPoint += 25;

                    // Om tabben har en sträng att visa, använd den. Annars kan du anpassa för mer data
                    if (!string.IsNullOrEmpty(tab.DisplayContent))
                    {
                        gfx.DrawString(tab.DisplayContent, fontNormal, XBrushes.Black, new XRect(50, yPoint, page.Width - 100, 500), XStringFormats.TopLeft);
                        yPoint += 50;
                    }

                    yPoint += 10;

                    // Om yPoint är för långt ner på sidan, skapa ny sida
                    if (yPoint > page.Height - 100)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        yPoint = 40;
                    }
                }

                // Spara PDF i Documents
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filename = System.IO.Path.Combine(documentsPath, "KajsaJosefssonCV.pdf");
                document.Save(filename);

                // Öppna PDF
                Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Fel vid skapande av PDF: " + ex.Message);
            }
        }
    }
}