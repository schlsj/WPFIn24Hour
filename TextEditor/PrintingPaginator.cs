using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace TextEditor
{
    class PrintingPaginator:DocumentPaginator
    {
        private readonly DocumentPaginator originalPaginator;
        private readonly Size pageSize;
        private readonly Size pageMargin;

        public PrintingPaginator(DocumentPaginator paramPaginator, Size paramSize, Size paramMargin)
        {
            originalPaginator = paramPaginator;
            pageSize = paramSize;
            pageMargin = paramMargin;
            originalPaginator.PageSize=new Size(pageSize.Width-pageMargin.Width*2,pageSize.Height-pageMargin.Height*2);
            originalPaginator.ComputePageCount();
        }
        public override DocumentPage GetPage(int pageNumber)
        {
            DocumentPage originalPage = originalPaginator.GetPage(pageNumber);
            ContainerVisual fixedPage=new ContainerVisual();
            fixedPage.Children.Add(originalPage.Visual);
            fixedPage.Transform = new TranslateTransform(pageMargin.Width, pageMargin.Height);
            return new DocumentPage(fixedPage, pageSize, AdjustForMargins(originalPage.BleedBox),
                AdjustForMargins(originalPage.ContentBox));
        }

        private Rect AdjustForMargins(Rect rect)
        {
            if (rect.IsEmpty)
            {
                return rect;
            }
            else
            {
                return new Rect(rect.Left+pageMargin.Width,rect.Top+pageMargin.Height,rect.Width,rect.Height);
            }
        }

        public override bool IsPageCountValid
        {
            get { return originalPaginator.IsPageCountValid; }
        }

        public override int PageCount
        {
            get { return originalPaginator.PageCount; }
        }

        public override Size PageSize
        {
            get { return originalPaginator.PageSize; }
            set { originalPaginator.PageSize = value; }
        }

        public override IDocumentPaginatorSource Source
        {
            get { return originalPaginator.Source; }
        }
    }
}
