using System.Windows;
using ContactManager.Presenters;

namespace ContactManager.UserControls
{
    /// <summary>
    /// Interaction logic for SideBar.xaml
    /// </summary>
    public partial class SideBar
    {
        public SideBar()
        {
            InitializeComponent();
        }

        public ApplicationPresenter Presenter => DataContext as ApplicationPresenter;

        private void New_Clicked(object sender, RoutedEventArgs e)
        {
            Presenter.NewContact(); 
        }


        private void ViewAll_Clicked(object sender, RoutedEventArgs e)
        {
            Presenter.DisplayAllContacts();
        }
    }
}
