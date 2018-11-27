using System.Windows;
using MediaViewer.Presenters;

namespace MediaViewer.Views
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView
    {
        public MenuView(MenuPresenter presenter)
        {
            InitializeComponent();
            DataContext = presenter;
        }

        public MenuPresenter Presenter => DataContext as MenuPresenter;

        private void Video_Clicked(object sender, RoutedEventArgs e)
        {
            Presenter.WatchVideo();
        }

        private void Music_Clicked(object sender, RoutedEventArgs e)
        {
            Presenter.ListenToMusic();
        }

        private void Pictures_Clicked(object sender, RoutedEventArgs e)
        {
            Presenter.DisplayPictures();
        }
    }
}
