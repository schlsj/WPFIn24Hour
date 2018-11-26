using System.Windows;
using System.Windows.Controls;
using ContactManager.Model;
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

        private void OpenContact_Clicked(object sender, RoutedEventArgs e)
        {
            Button button=e.OriginalSource as Button;
            if (button != null)
            {
                Presenter.OpenContact(button.DataContext as Contact);
            }
        }
    }
}
