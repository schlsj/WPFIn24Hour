using System.Windows;
using ContactManager.Presenters;
using Microsoft.Win32;

namespace ContactManager.Views
{
    /// <summary>
    /// Interaction logic for EditContactView.xaml
    /// </summary>
    public partial class EditContactView
    {
        public EditContactView()
        {
            InitializeComponent();
        }

        public EditContactPresenter Presenter => DataContext as EditContactPresenter;

        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
            Presenter.Save();
        }

        private void Delete_Clicked(object sender, RoutedEventArgs e)
        {
            Presenter.Delete();
        }

        private void Close_Clicked(object sender, RoutedEventArgs e)
        {
            Presenter.Close();
        }

        private void SelectImage_Clicked(object sender, RoutedEventArgs e)
        {
            Presenter.SelectImage();
        }

        public string AskUserForImagePath()
        {
            OpenFileDialog dlg=new OpenFileDialog();
            dlg.ShowDialog();
            return dlg.FileName;
        }
    }
}
