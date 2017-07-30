using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using PuzzleSolver;
using PuzzleSolver.Classes;
using TwoWaterJugPuzzle.ViewModels;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace TwoWaterJugPuzzle.Views
{
    /// <summary>
    ///     UI Interaction logic for SolutionWindow.xaml
    /// </summary>
    public partial class SolutionWindow : Window
    {
        #region Fields
        private readonly StringBuilder _instructions = new StringBuilder();
        private readonly StringBuilder _parameters = new StringBuilder();
        private WaterJugModel _jugModel;
        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        const uint MF_BYCOMMAND = 0x00000000;
        const uint MF_GRAYED = 0x00000001;
        const uint MF_ENABLED = 0x00000000;
        const uint SC_CLOSE = 0xF060;
        const int WM_SHOWWINDOW = 0x00000018;
        const int WM_CLOSE = 0x10;
        #endregion

        #region Constructors
        public SolutionWindow(SolutionViewModel vm)
        {
            InitializeComponent();
            ConstructorInitializationLogic(vm);
        }
        #endregion

        #region Listeners
        private void OnWindowLoadedEventHandler(object sender, RoutedEventArgs e)
        {
            _stackPanelControl.Visibility = Visibility.Visible;
            _closeButton.IsEnabled = false;
            RunJugPuzzleSolverAsync();
        }

        private void OnCloseWindowButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            Close();
            e.Handled = true;
        }
        #endregion

        #region Methods
        private void ConstructorInitializationLogic(SolutionViewModel vm)
        {
            DataContext = vm;
            _jugModel = new WaterJugModel(0, 0, vm.A, vm.B, vm.C);
        }

        private async Task RunJugPuzzleSolverAsync()
        {
            // Runs Background Logic and waits before proceeding to update the UI.
            await Task.Run(() =>
            {
                try
                {
                    CreateSentenceInstructions();
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Too many steps to list...Please pick smaller numbers");
                    Dispatcher.BeginInvoke(new Action(() => { this.Close(); }));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                    Dispatcher.BeginInvoke(new Action(() => { this.Close(); }));
                }
            });
            var vm = DataContext as SolutionViewModel;
            UpdateUILogic(vm);
        }

        private void CreateSentenceInstructions()
        {
            var result = TwoWaterJugPuzzleSolver.GetJugFillInstructions(ref _jugModel).Split('\n');
            for (var i = 0; i < result.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    _instructions.Append(result[i]);
                }
                else
                {
                    _parameters.Append(result[i]);
                }
            }
        }
      
        private void UpdateUILogic(SolutionViewModel vm)
        {
            vm.Instructions = _instructions.ToString();
            vm.Parameters = _parameters.ToString();
            _stackPanelControl.Visibility = Visibility.Collapsed;
            _closeButton.IsEnabled = true;
        }
        #endregion

        #region Disable Window Close Button Logic
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;

            if (hwndSource != null)
            {
                hwndSource.AddHook(new HwndSourceHook(this.hwndSourceHook));
            }
        }
        
        IntPtr hwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_SHOWWINDOW)
            {
                IntPtr hMenu = GetSystemMenu(hwnd, false);
                if (hMenu != IntPtr.Zero)
                {
                    EnableMenuItem(hMenu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED);
                }
            }
            else if (msg == WM_CLOSE)
            {
                //handled = true;
            }
            return IntPtr.Zero;
        }
        #endregion
    }
}
