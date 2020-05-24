using System.Threading.Tasks;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Dialogs;
using MaterialXAMLDialogs.Enums;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.ViewModels;

namespace MaterialXAMLDialogs
{
	public class AlertDialog
	{
		// Fields
		private static readonly Task<DialogResult> _completedTask = Task.FromResult(DialogResult.None);
		private UserControl _dialogView;
		private IDialogViewModel _dialogViewModel;
		private DialogSession _dialogSession;
		private bool _isOpen;

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
				return _completedTask;
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
		public void Close()
		{
			_dialogSession?.Close();
			_isOpen = false;
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
		private void OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
		{
			if (eventArgs.Parameter != null)
			{
				Result = (DialogResult)eventArgs.Parameter;
				// replace with Interface
				AdditionalOptionChecked = (_dialogViewModel as AlertViewModel).IsAdditionalOptionChecked;
			}
			else
			{
				Result = DialogResult.None;
			}
			_isOpen = false;
		}
		private void OnDialogOpened(object sender, DialogOpenedEventArgs eventArgs)
		{
			_dialogSession = eventArgs.Session;
		}
	}
}
