using System.Windows;
using System.Windows.Controls;

namespace GenericEventHandler
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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) e.Source;
            Output.Text = $"You chose the color {button.Content}";
            Output.Background = button.Foreground;
        }
    }
}
