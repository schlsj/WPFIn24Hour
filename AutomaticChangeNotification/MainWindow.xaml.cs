using System.Windows;

namespace AutomaticChangeNotification
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext=new Person();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ((Person) DataContext).FirstName = "My New Name";
        }
    }
}
