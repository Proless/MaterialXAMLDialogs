using System.Threading.Tasks;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Dialogs;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.ViewModels;

namespace MaterialXAMLDialogs
{
	public class IndeterminateDialog
	{
		// Fields
		private static readonly Task<object> _completedTask = Task.FromResult<object>(null);
		private UserControl _dialogView;
		private IDialogViewModel _dialogViewModel;
		private DialogSession _dialogSession;
		private bool _isOpened;

		// Constructors
		public IndeterminateDialog()
		{
			_isOpened = false;
		}

		// Methods
		public Task Show(string dialogHostId, string title, string supportingText, bool showTitleSeparator)
		{
			InitializeDialog(title, supportingText, showTitleSeparator);
			if (_isOpened)
			{
				return _completedTask;
			}
			else
			{
				_isOpened = true;
				return DialogHost.Show(_dialogView, dialogHostId, OnDialogOpened, OnDialogClosing);
			}
		}
		public void Update(string title = null, string supportingText = null)
		{
			var vm = (_dialogViewModel as IndeterminateViewModel);
			vm.Title = title ?? vm.Title;
			vm.SupportingText = supportingText ?? vm.SupportingText;
		}
		public void Close()
		{
			if (_dialogSession != null && !_dialogSession.IsEnded)
			{
				_dialogSession.Close();
			}
			_isOpened = false;
		}

		// Helpers
		private void InitializeDialog(string title, string supportingText, bool showTitleSeparator)
		{
			_dialogViewModel = new IndeterminateViewModel
			{
				Title = title,
				SupportingText = supportingText,
				ShowTitleSeparator = showTitleSeparator
			};

			_dialogView = new IndeterminateView
			{
				DataContext = _dialogViewModel
			};
		}
		private void OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
		{
			_isOpened = false;
		}
		private void OnDialogOpened(object sender, DialogOpenedEventArgs eventArgs)
		{
			_dialogSession = eventArgs.Session;
		}
	}
}
