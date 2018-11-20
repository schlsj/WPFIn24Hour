using System.Windows;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for PrintPreviewDialog.xaml
    /// </summary>
    public partial class PrintPreviewDialog 
    {
        public static readonly DependencyProperty CurrentPageProperty=DependencyProperty.Register(
            "CurrentPage",typeof(int),typeof(PrintPreviewDialog));

        public int CurrentPage
        {
            get { return (int) GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        private readonly PrintManager manager;
        private int pageIndex;
        public PrintPreviewDialog(PrintManager paramManager)
        {
            InitializeComponent();
            manager = paramManager;
            DataContext = this;
            ChangePage(0);
        }

        private void ChangePage(int requestedPage)
        {
            PageViewer.DocumentPaginator = manager.GetPaginator(8.5 * PrintManager.DPI, 11 * PrintManager.DPI);
            if (requestedPage < 0)
            {
                pageIndex = 0;
            }
            else if(requestedPage >= PageViewer.DocumentPaginator.PageCount)
            {
                pageIndex = PageViewer.DocumentPaginator.PageCount - 1;
            }
            else
            {
                pageIndex = requestedPage;
            }

            PageViewer.PageNumber = pageIndex;
            CurrentPage = pageIndex + 1;
        }

        private void PreviousClick(object sender, RoutedEventArgs e)
        {
            ChangePage(pageIndex - 1);
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            ChangePage(pageIndex + 1);
        }
    }
}
