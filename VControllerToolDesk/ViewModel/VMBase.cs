using System.ComponentModel;
using System.Runtime.CompilerServices;

//Disabled nullable warning.
#pragma warning disable CS8612
#pragma warning disable CS8618

namespace VControllerToolDesk.ViewModel
{
    /// <summary>
    /// Base class of view models.
    /// </summary>
    internal abstract class VMBase : INotifyPropertyChanged
    {
        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Events

        #region Protected Methods

        /// <summary>
        /// Raise <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="name">[Auto] filled with caller's name.</param>
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion Protected Methods
    }
}