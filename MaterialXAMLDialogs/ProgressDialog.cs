using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Dialogs;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.ViewModels;

namespace MaterialXAMLDialogs
{
	public class ProgressDialog
	{
		// Fields
		private static readonly Task<object> _completedTask = Task.FromResult<object>(null);
		private UserControl _dialogView;
		private IDialogViewModel _dialogViewModel;
		private DialogSession _dialogSession;
		private bool _isOpened;


		// Constructors
		public ProgressDialog(ProgressDialogConfiguration configuration)
		{
			_isOpened = false;
			InitializeDialog(configuration);
		}

		// Methods
		public Task Show(string dialogHostId, CancellationTokenSource cancellationTokenSource)
		{
			if (_isOpened)
			{
				return _completedTask;
			}
			else
			{
				// replace with Interface
				(_dialogViewModel as ProgressViewModel).CancellationTokenSource = cancellationTokenSource;
				_isOpened = true;
				return DialogHost.Show(_dialogView, dialogHostId, OnDialogOpened, OnDialogClosing);
			}
		}
		public void Close(bool cancel = false)
		{
			if (_dialogSession != null && !_dialogSession.IsEnded)
			{
				if (cancel)
				{
					// replace with Interface
					(_dialogViewModel as ProgressViewModel).CancellationTokenSource?.Cancel();
				}
				_dialogSession.Close();
			}
			_isOpened = false;
		}
		public void UpdateDialog(bool cancellable, bool isIndeterminate, string title = null, string supportingText = null)
		{
			// replace with Interface
			var _viewModel = (_dialogViewModel as ProgressViewModel);
			_viewModel.Cancellable = cancellable;
			_viewModel.IsIndeterminate = isIndeterminate;
			_viewModel.Title = title ?? _viewModel.Title;
			_viewModel.SupportingText = supportingText ?? _viewModel.SupportingText;
		}
		public void ShowProgress(double progress, string progressText = null)
		{
			// replace with Interface
			var _viewModel = (_dialogViewModel as ProgressViewModel);
			_viewModel.Progress = progress;
			_viewModel.ProgressText = progressText;
		}

		// Helpers
		private void InitializeDialog(ProgressDialogConfiguration configuration)
		{
			_dialogViewModel = new ProgressViewModel
			{
				Cancellable = configuration.Cancellable,
				IconBrush = configuration.IconBrush,
				IconKind = configuration.IconKind,
				IsIndeterminate = configuration.IsIndeterminate,
				ShowTitleSeparator = configuration.ShowTitleSeparator,
				SupportingText = configuration.SupportingText,
				Title = configuration.Title
			};

			_dialogView = new ProgressView()
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
			// replace with Interface
			(_dialogViewModel as ProgressViewModel).Session = eventArgs.Session;
		}
	}
}
