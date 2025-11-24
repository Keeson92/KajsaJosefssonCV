using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace KajsaJosefssonCV.Services
{
    public class PdfService
    {
        public void CreatePdf()
        {
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Mitt CV";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20);
            gfx.DrawString("Mitt CV", font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height), XStringFormats.TopCenter);

            document.Save("CvExport.pdf");
        }
    }
}