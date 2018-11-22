using System.Windows;
using System.Windows.Controls;
using ContactManager.Presenters;

namespace ContactManager.UserControls
{
    /// <summary>
    /// Interaction logic for SearchBar.xaml
    /// </summary>
    public partial class SearchBar
    {
        public SearchBar()
        {
            InitializeComponent();
        }

        public ApplicationPresenter Presenter => DataContext as ApplicationPresenter;

        private void SearchText_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Presenter.Search(SearchText.Text);
        }
    }
}
