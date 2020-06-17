using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Dialogs;
using MaterialXAMLDialogs.Enums;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.Interfaces.DialogViewModels;
using MaterialXAMLDialogs.ViewModels;

namespace MaterialXAMLDialogs
{
	public class AlertDialog : DialogBase<DialogResult>
	{
		// Fields
		private IAlertViewModel _dialogViewModel;

		// Properties
		public DialogResult Result { get; private set; }
		public bool AdditionalOptionChecked { get; private set; }

		// Constructors
		public AlertDialog(AlertDialogConfiguration configuration) : base()
		{
			_isOpen = false;
			InitializeDialog(configuration);
		}

		// Methods
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
				IsAdditionalOptionChecked = configuration.IsAdditionalOptionCheched
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
