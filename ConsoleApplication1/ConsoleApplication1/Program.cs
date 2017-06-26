using DevExpress.Pdf;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PdfDocumentProcessor documentProcessor = new PdfDocumentProcessor())
            {
                documentProcessor.CreateEmptyDocument();
                PdfPage page = documentProcessor.AddNewPage(PdfPaperSize.A4);
                Draw(page);
                documentProcessor.SaveDocument("..\\..\\Result.pdf");
            }
        }
        static void Draw(PdfPage page)
        {
            using (PdfGraphics graphics = new PdfGraphics())
            {
                using (Bitmap image = new BitmapFrame()("..\\..\\Northwind.png"))
                {
                    float width = image.Width;
                    float height = image.Height;
                    graphics.DrawImage(image, new RectangleF(100, 100, width / 2, height / 2));
                }
                graphics.AddToPageForeground(page);
            }
        }
    }
}
