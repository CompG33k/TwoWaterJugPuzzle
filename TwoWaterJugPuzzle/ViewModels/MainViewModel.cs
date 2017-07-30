using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using PuzzleSolver;
using TwoWaterJugPuzzle.Views;

namespace TwoWaterJugPuzzle.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private int _a = 3;
        private int _b = 5;
        private int _c = 4;

        private ICommand _buttonCommanClicked;
        #endregion

        #region Properties
        public int A
        {
            get { return _a; }
            set
            {
                if (_a != value)
                {
                    _a = value;
                    OnPropertyChanged("A");
                }
            }
        }

        public int B
        {
            get { return _b; }
            set
            {
                if (_b != value)
                {
                    _b = value;
                    OnPropertyChanged("B");
                }
            }
        }

        public int C
        {
            get { return _c; }
            set
            {
                if (_c != value)
                {
                    _c = value;
                    OnPropertyChanged("C");
                }
            }
        }

        public ICommand ButtonCommanClicked
        {
            get
            {
                return _buttonCommanClicked ?? (_buttonCommanClicked = new RelayCommand(
                    () =>
                    {
                        //Validate user input if possible combination entry
                        if (EquationProvider.IsBezoutsCoefficientsValid(A, B, C))
                        {
                            var vm = new SolutionViewModel(_a, _b, _c);
                            var w = new SolutionWindow(vm);
                            w.Owner = Application.Current.MainWindow; 
                            w.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("This Compination of numbers is not going to work.\n Pick other numbers.");
                        }
                    }));
            }
        }
        #endregion
    }
}
