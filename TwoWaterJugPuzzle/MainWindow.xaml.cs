using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace TwoWaterJugPuzzle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        private readonly Regex _regex;
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            _regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        }
        #endregion

        private void CloseWindowButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #region Methods
        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        #endregion
    }
}
