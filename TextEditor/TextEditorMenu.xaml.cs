using System;
using System.Windows;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for TextEditorMenu.xaml
    /// </summary>
    public partial class TextEditorMenu 
    {
        public TextEditorMenu()
        {
            InitializeComponent();
        }

        private void About_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Teach Yourself WPF in 24 Hours - Text Editor", "About");
        }

        private void Exception(object sender, RoutedEventArgs e)
        {
            throw new Exception();
        }
    }
}
