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

                // App-färger: lila/beige
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

                double yPoint = 40;

                // Header bakgrund
                gfx.DrawRectangle(new XSolidBrush(lightPurple), 0, 0, page.Width, 100);

                // Namn
                gfx.DrawString(viewModel.HeaderName, fontName, brushHeaderText, new XRect(40, yPoint, page.Width - 80, 30), XStringFormats.TopLeft);
                yPoint += 35;

                // Titel
                gfx.DrawString(viewModel.HeaderTitle, fontTitle, brushHeaderText, new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                yPoint += 25;

                // Kontaktinfo
                gfx.DrawString("Email: " + viewModel.HeaderEmail, fontNormal, brushHeaderText, new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                yPoint += 18;
                gfx.DrawString("Telefon: " + viewModel.HeaderPhone, fontNormal, brushHeaderText, new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                yPoint += 35;

                // Divider-linje
                gfx.DrawLine(new XPen(purpleColor, 1.5), 40, yPoint, page.Width - 40, yPoint);
                yPoint += 20;

                // Flikar / innehåll
                foreach (var tab in viewModel.Tabs)
                {
                    // Tab header
                    gfx.DrawString(tab.TabHeader, fontTitle, brushSubHeader, new XRect(40, yPoint, page.Width - 80, 20), XStringFormats.TopLeft);
                    yPoint += 22;

                    // Tab content: iterera över ContentItems
                    foreach (var item in tab.ContentItems)
                    {
                        if (!string.IsNullOrWhiteSpace(item))
                        {
                            gfx.DrawString(item, fontNormal, brushNormalText, new XRect(50, yPoint, page.Width - 100, 500), XStringFormats.TopLeft);
                            yPoint += 20; // justera höjd mellan rader
                        }

                        // Ny sida om yPoint är för långt ner
                        if (yPoint > page.Height - 80)
                        {
                            page = document.AddPage();
                            gfx = XGraphics.FromPdfPage(page);
                            yPoint = 40;
                        }
                    }

                    yPoint += 10; // extra mellanrum efter varje tab
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