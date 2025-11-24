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
                document.Info.Title = "CV – " + viewModel.HeaderName;

                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Färger
                XColor purpleColor = XColor.FromArgb(140, 102, 204); // #8C66CC
                XColor lightPurple = XColor.FromArgb(179, 153, 230); // #B399E6
                XColor beigeColor = XColor.FromArgb(245, 245, 220); // Beige

                XBrush brushHeaderText = new XSolidBrush(beigeColor);
                XBrush brushSubHeader = new XSolidBrush(purpleColor);
                XBrush brushNormalText = XBrushes.Black;

                // Fonts
                XFont fontName = new XFont("Verdana", 24, XFontStyle.Bold);
                XFont fontTitle = new XFont("Verdana", 14, XFontStyle.Bold);
                XFont fontNormal = new XFont("Verdana", 12, XFontStyle.Regular);
                XFont fontBold = new XFont("Verdana", 12, XFontStyle.Bold);

                double yPoint = 40;

                // Header bakgrund
                gfx.DrawRectangle(new XSolidBrush(lightPurple), 0, 0, page.Width, 100);

                // Namn
                gfx.DrawString(viewModel.HeaderName, fontName, brushHeaderText,
                    new XRect(40, yPoint, page.Width - 80, 30), XStringFormats.TopLeft);
                yPoint += 35;

                // Titel
                gfx.DrawString(viewModel.HeaderTitle, fontTitle, brushHeaderText,
                    new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                yPoint += 25;

                // Kontaktinfo
                gfx.DrawString("Email: " + viewModel.HeaderEmail, fontNormal, brushHeaderText,
                    new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                yPoint += 18;
                gfx.DrawString("Telefon: " + viewModel.HeaderPhone, fontNormal, brushHeaderText,
                    new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                yPoint += 35;

                // Divider-linje
                gfx.DrawLine(new XPen(purpleColor, 1.5), 40, yPoint, page.Width - 40, yPoint);
                yPoint += 20;

                // Loop över alla flikar
                foreach (var tab in viewModel.Tabs)
                {
                    // Tab header
                    gfx.DrawString(tab.TabHeader, fontTitle, brushSubHeader,
                        new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                    yPoint += 22;

                    // Tab content
                    foreach (var line in tab.ContentItems)
                    {
                        // Fet stil för rader med "-" i början (exempelvis "Titel - Företag (Period)")
                        bool isBold = line.Contains(" - "); // kan ändras till mer avancerad logik
                        XFont fontToUse = isBold ? fontBold : fontNormal;

                        gfx.DrawString(line, fontToUse, brushNormalText,
                            new XRect(50, yPoint, page.Width - 100, 500), XStringFormats.TopLeft);
                        yPoint += 18;

                        // Ny sida om yPoint blir för långt ner
                        if (yPoint > page.Height - 80)
                        {
                            page = document.AddPage();
                            gfx = XGraphics.FromPdfPage(page);
                            yPoint = 40;
                        }
                    }

                    yPoint += 10; // extra rad mellan flikar
                }

                // Spara PDF
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