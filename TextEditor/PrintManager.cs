using System.IO;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TextEditor
{
    public class PrintManager
    {
        // ReSharper disable once InconsistentNaming
        public static readonly int DPI = 96;
        private readonly RichTextBox textBox;

        public PrintManager(RichTextBox paramTextBox)
        {
            textBox = paramTextBox;
        }

        public bool Print()
        {
            PrintDialog dlg=new PrintDialog();
            if (dlg.ShowDialog() == true)
            {
                PrintQueue printQueue = dlg.PrintQueue;
                DocumentPaginator paginator = GetPaginator(printQueue.UserPrintTicket.PageMediaSize.Width.Value,
                    printQueue.UserPrintTicket.PageMediaSize.Height.Value);
                dlg.PrintDocument(paginator, "TextEditor Printing");
                return true;
            }

            return false;
        }

        public DocumentPaginator GetPaginator(double pageWidth, double pageHeight)
        {
            TextRange originalRange = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
            MemoryStream memoryStream = new MemoryStream();
            originalRange.Save(memoryStream,DataFormats.Xaml);
            FlowDocument copy = new FlowDocument();
            TextRange copyRange=new TextRange(copy.ContentStart,copy.ContentEnd);
            copyRange.Load(memoryStream, DataFormats.Xaml);
            return new PrintingPaginator(((IDocumentPaginatorSource)copy).DocumentPaginator, new Size(pageWidth, pageHeight), new Size(DPI, DPI));
        }

        public void PrintPreview()
        {
            PrintPreviewDialog dlg = new PrintPreviewDialog(this);
            dlg.ShowDialog();
        }
    }
}
