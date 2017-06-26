using System.Drawing;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DevExpress.Xpf.Core;
using DevExpress.Pdf;
using DevExpress.Xpf.PdfViewer;


namespace SignaturePadPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow
    {
        System.Windows.Point currentPoint = new System.Windows.Point(0,0);
        System.Windows.Point endPoint = new System.Windows.Point(0,0);
        public MainWindow()
        {
            InitializeComponent();
            
            //using (PdfDocumentProcessor documentProcessor = new PdfDocumentProcessor())
            //{
            //    documentProcessor.CreateEmptyDocument();
            //    PdfPage page = documentProcessor.AddNewPage(PdfPaperSize.A4);
            //    Draw(page, documentProcessor);
            //    documentProcessor.SaveDocument("C:\\Users\\nschroeder\\Documents\\Result.pdf");
            //}
        }
        static void Draw(PdfPage page, PdfDocumentProcessor processor, PdfDocumentPosition position, float z)
        {
            using (DevExpress.Pdf.PdfGraphics graphics = processor.CreateGraphics())
            {
                using (Bitmap image = new Bitmap("C:\\Users\\nschroeder\\Pictures\\download.png"))
                {
                    float width = image.Width;
                    float height = image.Height;
                    graphics.DrawImage(image, new RectangleF((float)position.Point.X, z+110-(float)position.Point.Y, width/2,height/2));
                }
                graphics.AddToPageForeground(page);
            }
        }
        private void PdfViewerControl_OnSelectionStarted(DependencyObject d, SelectionEventArgs e)
        {
            currentPoint = PointToScreen(currentPoint);
            //currentPoint = Mouse.GetPosition(Control);
        }

        private void Control_OnSelectionEnded(DependencyObject d, SelectionEventArgs e)
        {
            
            //endPoint = PointToScreen(endPoint);
            //PdfDocumentPosition position = Control.ConvertPixelToDocumentPosition(endPoint);
            using (PdfDocumentProcessor documentProcessor = new PdfDocumentProcessor())
            {
                documentProcessor.LoadDocument("C:\\Users\\nschroeder\\Documents\\EmailDownloads\\SampleCreditCardPre-Authorizationform.pdf");
                PdfPage page = documentProcessor.Document.Pages[Control.CurrentPageNumber-1];
                double z = page.CropBox.Height;
                Draw(page, documentProcessor, e.DocumentPosition, (float)z);
                documentProcessor.SaveDocument("C:\\Users\\nschroeder\\Documents\\Result.pdf");
            }
       }
    }
}
