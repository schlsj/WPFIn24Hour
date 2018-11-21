namespace ContactManager.Presenters
{
    public class PresenterBase<T>:Notifier
    {
        private readonly string _tabHeaderPath;
        private readonly T _view;

        public PresenterBase(T view)
        {
            _view = view;
        }

        public PresenterBase(T veiw, string tabHeaderPath)
        {
            _view = veiw;
            _tabHeaderPath = tabHeaderPath;
        }

        public T View => _view;

        public string TabHeaderPath => _tabHeaderPath;
    }
}
