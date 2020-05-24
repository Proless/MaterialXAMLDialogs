using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Dialogs;
using MaterialXAMLDialogs.Enums;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.ViewModels;

namespace MaterialXAMLDialogs
{
	public class ProgressDialog
	{
		// Fields
		private static readonly Task<DialogResult> _completedTask = Task.FromResult(DialogResult.None);
		private UserControl _dialogView;
		private IDialogViewModel _dialogViewModel;
		private DialogSession _dialogSession;
		private bool _isOpened;
		private CancellationTokenSource _cancellationTokenSource;

		// Properties
		public DialogResult Result { get; private set; }

		// Constructors
		public ProgressDialog(ProgressDialogConfiguration configuration)
		{
			_isOpened = false;
			InitializeDialog(configuration);
		}

		// Methods
		public Task<DialogResult> Show(string dialogHostId, CancellationTokenSource cancellationTokenSource)
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
				return DialogHost.Show(_dialogView, dialogHostId, OnDialogOpened, OnDialogClosing).ContinueWith(t =>
				{
					return Result;
				});
			}
		}
		public void Close(bool cancel = false)
		{
			if (cancel)
			{
				// replace with Interface
				(_dialogViewModel as ProgressViewModel).CancellationTokenSource?.Cancel();
				_dialogSession?.Close(true);
			}
			else
			{
				_dialogSession?.Close(false);
			}
			_isOpened = false;
		}
		public void UpdateDialog(double progress, string progressText = null, string titel = null, string supportingText = null, bool cancellable = true, bool isIndeterminate = false)
		{
			// replace with Interface
			var _viewModel = (_dialogViewModel as ProgressViewModel);
			_viewModel.Progress = progress;
			_viewModel.ProgressText = progressText ?? _viewModel.ProgressText;
			_viewModel.Cancellable = cancellable;
			_viewModel.IsIndeterminate = isIndeterminate;
			_viewModel.Title = titel ?? _viewModel.Title;
			_viewModel.SupportingText = supportingText ?? _viewModel.SupportingText;
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
			if (eventArgs.Parameter != null)
			{
				Result = (bool)eventArgs.Parameter ? DialogResult.Cancelled : DialogResult.None;
			}
			else
			{
				Result = DialogResult.None;
			}
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
