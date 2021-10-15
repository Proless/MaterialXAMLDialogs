using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Dialogs;
using MaterialXAMLDialogs.Enums;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.Interfaces.DialogViewModels;
using MaterialXAMLDialogs.ViewModels;
using System.Threading.Tasks;

namespace MaterialXAMLDialogs
{
    public class AlertDialog : DialogBase<DialogResult>
    {
        // Fields
        private IAlertViewModel _dialogViewModel;

        /// <summary>
        /// The result of the dialog Show method.
        /// </summary>
        public DialogResult Result { get; private set; }

        /// <summary>
        /// Determines the state of the additional checkBox after the dialog is closed.
        /// </summary>
        public bool AdditionalOptionChecked { get; private set; }

        /// <summary>
        /// A dialog to use when an action requires user interaction or just display a warning or information.
        /// </summary>
        /// <param name="configuration">Configure the look and properties of the dialog</param>
        public AlertDialog(AlertDialogConfiguration configuration) : base()
        {
            _isOpen = false;
            InitializeDialog(configuration);
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="dialogHosId">The Identifier of the DialogHost instance where the dialog should be shown</param>
        /// <returns>The result of the dialog chosen by the user</returns>
        public Task<DialogResult> Show(string dialogHosId)
        {
            if (_isOpen)
            {
                return _defaultCompletedTask;
            }
            else
            {
                _isOpen = true;
                return DialogHost.Show(_dialogView, dialogHosId, OnDialogOpened, OnDialogClosing)
                    .ContinueWith(t =>
                    {
                        return Result;
                    });
            }
        }

        // Helpers
        private void InitializeDialog(AlertDialogConfiguration configuration)
        {
            _dialogViewModel = new AlertViewModel
            {
                Title = configuration.Title,
                SupportingText = configuration.SupportingText,
                DialogButtons = configuration.DialogButtons,
                ShowAdditionalOption = configuration.ShowAdditionalOption,
                ShowTitleSeparator = configuration.ShowTitleSeparator,
                AdditionalOptionText = configuration.AdditionalOptionText,
                IconBrush = configuration.IconBrush,
                IconKind = configuration.IconKind,
                IsAdditionalOptionChecked = configuration.IsAdditionalOptionChecked
            };

            _dialogView = new AlertView
            {
                DataContext = _dialogViewModel
            };
        }
        protected override void OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter != null)
            {
                Result = (DialogResult)eventArgs.Parameter;
                AdditionalOptionChecked = _dialogViewModel.IsAdditionalOptionChecked;
            }
            else
            {
                Result = DialogResult.None;
            }
            _isOpen = false;
        }
    }
}
