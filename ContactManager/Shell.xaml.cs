using System.Windows.Controls;
using System.Windows.Data;
using ContactManager.Model;
using ContactManager.Presenters;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell 
    {
        public Shell()
        {
            InitializeComponent();
            DataContext=new ApplicationPresenter(this, new ContactRepository());
        }

        public void AddTab<T>(PresenterBase<T> presenter)
        {
            TabItem newTab = null;
            for (int i = 0; i < Tabs.Items.Count; i++)
            {
                TabItem existingTab = (TabItem) Tabs.Items[i];
                if (existingTab.DataContext.Equals(presenter))
                {
                    Tabs.Items.Remove(existingTab);
                    newTab = existingTab;
                    break;
                }
            }
            if (newTab == null)
            {
                newTab=new TabItem();
                Binding headerBinding=new Binding(presenter.TabHeaderPath);
                BindingOperations.SetBinding(newTab, HeaderedContentControl.HeaderProperty, headerBinding);
                newTab.DataContext = presenter;
                newTab.Content = presenter.View;
            }
            Tabs.Items.Insert(0, newTab);
            newTab.Focus();
        }

        public void RemoveTab<T>(PresenterBase<T> presenter)
        {
            for (int i = 0; i < Tabs.Items.Count; i++)
            {
                TabItem item = (TabItem) Tabs.Items[i];
                if (item.DataContext.Equals(presenter))
                {
                    Tabs.Items.Remove(item);
                    break;
                }
            }
        }
    }
}
