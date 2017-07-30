using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using PuzzleSolver;
using PuzzleSolver.Classes;
using TwoWaterJugPuzzle.ViewModels;

namespace TwoWaterJugPuzzle.Views
{
    /// <summary>
    ///     UI Interaction logic for SolutionWindow.xaml
    /// </summary>
    public partial class SolutionWindow : Window
    {
        #region Fields
        private readonly BackgroundWorker _bw = new BackgroundWorker() { WorkerSupportsCancellation =true};
        private readonly StringBuilder _instructions = new StringBuilder();
        private readonly StringBuilder _parameters = new StringBuilder();
        private WaterJugModel _jugModel;
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
            _bw.RunWorkerAsync();
        }

        private void OnCloseWindowButtonClickedEventHandler(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion

        #region Methods
        private void ConstructorInitializationLogic(SolutionViewModel vm)
        {
            DataContext = vm;
            _bw.DoWork += worker_DoWork;
            _bw.RunWorkerCompleted += worker_RunWorkerCompleted;
            _jugModel = new WaterJugModel(0, 0, vm.A, vm.B, vm.C);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // run all background tasks here
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
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Too many steps to list...Please pick smaller numbers");
                Dispatcher.BeginInvoke(new Action(() => { Close(); }));
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //update ui once worker complete his work
            var vm = DataContext as SolutionViewModel;
            UpdateUILogic(vm);
        }

        private void UpdateUILogic(SolutionViewModel vm)
        {
            vm.Instructions = _instructions.ToString();
            vm.Parameters = _parameters.ToString();
            _stackPanelControl.Visibility = Visibility.Collapsed;
        }
        #endregion
    }
}
