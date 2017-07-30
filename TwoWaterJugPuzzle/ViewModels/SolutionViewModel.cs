namespace TwoWaterJugPuzzle.ViewModels
{
    public class SolutionViewModel : ViewModelBase
    {
        #region Fields
        private int _a = 3;
        private int _b = 5;
        private int _c = 4;
        private string _instructions;
        private string _parameters;
        private string _jugs;
        #endregion

        #region Properties
        public string Instructions
        {
            get { return _instructions; }
            set
            {
                if (_instructions != value)
                {
                    _instructions = value;
                    OnPropertyChanged("Instructions");
                }
            }
        }

        public string Parameters
        {
            get { return _parameters; }
            set
            {
                if (_parameters != value)
                {
                    _parameters = value;
                    OnPropertyChanged("Parameters");
                }
            }
        }

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
        #endregion

        #region Constructors
        public SolutionViewModel(int a, int b, int c)
        {
            _a = a;
            _b = b;
            _c = c;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Format("({0}-gallon jug, {1}-gallon jug)", A, B);
        }
        #endregion
    }
}
