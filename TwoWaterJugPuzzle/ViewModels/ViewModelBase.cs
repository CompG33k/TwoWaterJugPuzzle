using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TwoWaterJugPuzzle.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Listeners
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
