using System.Windows;
using MediaViewer.Presenters;

namespace MediaViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ApplicationController(this);
        }

        public ApplicationController Controller => (ApplicationController) DataContext;

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Controller.ShowMenu();
        }

        public void TranslationTo(object view)
        {
            CurrentView.Content = view;
        }

        private void Header_Clicked(object sender, RoutedEventArgs e)
        {
            Controller.ShowMenu();
        }
    }
}
