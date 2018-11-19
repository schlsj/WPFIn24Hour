using System.Windows.Input;

namespace PreviewEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Handler(object sender, KeyEventArgs e)
        {
            bool isPreview = e.RoutedEvent.Name.StartsWith("Preview");
            string direction = isPreview ? "v" : "^";
            Output.Items.Add($"{direction} {sender.GetType().Name}");
            if (sender == e.OriginalSource && isPreview)
            {
                Output.Items.Add("-{bounce}-");
            }

            if ((Equals(sender, this)) && !isPreview)
            {
                Output.Items.Add("-end-");
            }
        }
    }
}
