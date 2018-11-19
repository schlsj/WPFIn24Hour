using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for TextEditorToolbar.xaml
    /// </summary>
    public partial class TextEditorToolbar
    {
        public bool IsSynchronizing { get; private set; }
        public TextEditorToolbar()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            for (double i = 8; i < 48; i += 2)
            {
                FontSize.Items.Add(i);
            }
        }

        public void SynchronizeWith(TextSelection selection)
        {
            IsSynchronizing = true;
            Synchronize<double>(selection,TextBlock.FontSizeProperty,SetFontSize);
            Synchronize<FontWeight>(selection,TextBlock.FontWeightProperty,SetFontWeight);
            Synchronize<FontStyle>(selection,TextBlock.FontStyleProperty,SetFontStyle);
            Synchronize<TextDecorationCollection>(selection,TextBlock.TextDecorationsProperty,SetTextDecoration);
            Synchronize<FontFamily>(selection,TextBlock.FontFamilyProperty,SetFontFamily);
            IsSynchronizing = false;
        }

        private static void Synchronize<T>(TextSelection selection, DependencyProperty property, Action<T> methodToCall)
        {
            object value = selection.GetPropertyValue(property);
            if (value != DependencyProperty.UnsetValue)
            {
                methodToCall((T) value);
            }
        }

        private void SetFontSize(double size)
        {
            FontSize.SelectedValue = size;
        }

        private void SetFontWeight(FontWeight weight)
        {
            BoldButton.IsChecked = weight == FontWeights.Bold;
        }

        private void SetFontStyle(FontStyle style)
        {
            ItalicButton.IsChecked = style == FontStyles.Italic;
        }

        private void SetTextDecoration(TextDecorationCollection decoration)
        {
            UnderlineButton.IsChecked = decoration == TextDecorations.Underline;
        }

        private void SetFontFamily(FontFamily family)
        {
            Fonts.SelectedItem = family;
        }
    }
}
