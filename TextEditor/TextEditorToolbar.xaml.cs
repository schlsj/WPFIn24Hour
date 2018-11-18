using System.Windows;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for TextEditorToolbar.xaml
    /// </summary>
    public partial class TextEditorToolbar
    {
        public TextEditorToolbar()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            for (double i = 8; i < 48; i += 2)
            {
                FontSize.Items.Add(i);
            }
        }
    }
}
