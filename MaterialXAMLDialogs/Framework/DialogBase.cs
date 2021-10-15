using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MaterialXAMLDialogs.Framework
{
    public class DialogBase<T>
    {
        // Fields
        protected Task<T> _defaultCompletedTask = Task.FromResult(default(T));
        protected DialogSession _dialogSession;
        protected UserControl _dialogView;
        protected bool _isOpen;

        // Constructor
        internal DialogBase() { }

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        public virtual void Close()
        {
            if (_dialogSession != null && !_dialogSession.IsEnded)
            {
                _dialogSession.Close();
            }
            _isOpen = false;
        }

        // Helpers
        protected virtual void OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            _isOpen = false;
        }
        protected virtual void OnDialogOpened(object sender, DialogOpenedEventArgs eventArgs)
        {
            _dialogSession = eventArgs.Session;
        }
    }
}
