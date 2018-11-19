using System.Windows;
using System.Windows.Controls;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        private DocumentManager documentManager;
        public MainWindow()
        {
            InitializeComponent();
            documentManager = new DocumentManager(Body);
            if (documentManager.OpenDocument())
            {
                Status.Text = "Document loaded";
            }
        }

        private void Toolbar_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Toolbar.IsSynchronizing)
            {
                return;
            }
            ComboBox source=e.OriginalSource as ComboBox;
            if (source == null)
            {
                return;
            }
            switch (source.Name)
            {
                case "Fonts":
                    documentManager.ApplyToSelection(TextBlock.FontFamilyProperty, source.SelectedItem);
                    break;
                case "FontSize":
                    documentManager.ApplyToSelection(TextBlock.FontSizeProperty,source.SelectedItem);
                    break;
            }
            Body.Focus();
        }

        private void Body_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            Toolbar.SynchronizeWith(Body.Selection);
        }
    }
}
