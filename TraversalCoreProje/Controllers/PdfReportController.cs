using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);

            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporlama Islemi");

            document.Add(paragraph);
            document.Close();

            return File("/PdfReport/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);

            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("Musteri Adi");
            pdfPTable.AddCell("Musteri Soyadi");
            pdfPTable.AddCell("Musteri Sehir");

            pdfPTable.AddCell("Ayse");
            pdfPTable.AddCell("Yilmaz");
            pdfPTable.AddCell("Ankara");

            pdfPTable.AddCell("Deniz");
            pdfPTable.AddCell("Arda");
            pdfPTable.AddCell("Istanbul");

            pdfPTable.AddCell("Cem");
            pdfPTable.AddCell("Turan");
            pdfPTable.AddCell("Izmir");

            document.Add(pdfPTable);

            document.Close();

            return File("/PdfReport/dosya2.pdf", "application/pdf", "dosya2.pdf");

        }


        //public IActionResult DinamicPdfReport()
        //{

        //}


    }
}
