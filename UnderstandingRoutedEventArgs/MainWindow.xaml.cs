using System.Windows.Input;

namespace UnderstandingRoutedEventArgs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            object source = e.Source;
            object originalSource = e.OriginalSource;
        }
    }
}
