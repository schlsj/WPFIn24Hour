using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Microsoft.Win32;

namespace TextEditor
{
    class DocumentManager
    {
        private string currentFile;
        private RichTextBox textBox;

        public DocumentManager(RichTextBox paramTextBox)
        {
            textBox = paramTextBox;
        }

        public bool OpenDocument()
        {
            OpenFileDialog dlg=new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                currentFile = dlg.FileName;
                using (Stream stream = dlg.OpenFile())
                {
                    TextRange range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                    range.Load(stream,DataFormats.Rtf);
                }
                return true;
            }
            return false;
        }

        public bool SaveDocument()
        {
            if (string.IsNullOrEmpty(currentFile))
            {
                return SaveDocumentAs();
            }
            using (Stream stream = new FileStream(currentFile, FileMode.Create))
            {
                TextRange range = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                range.Save(stream, DataFormats.Rtf);
            }
            return true;
        }

        public bool SaveDocumentAs()
        {
            SaveFileDialog dlg=new SaveFileDialog();
            if (dlg.ShowDialog() == true)
            {
                currentFile = dlg.FileName;
                return SaveDocument();
            }
            return false;
        }
    }
}
