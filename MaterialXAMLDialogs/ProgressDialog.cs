using System.Threading;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Dialogs;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.Interfaces.DialogViewModels;
using MaterialXAMLDialogs.ViewModels;

namespace MaterialXAMLDialogs
{
	public class ProgressDialog : DialogBase<object>
	{
		// Fields
		private IProgressViewModel _dialogViewModel;

		// Constructors
		public ProgressDialog(ProgressDialogConfiguration configuration)
		{
			_isOpen = false;
			InitializeDialog(configuration);
		}

		// Methods
		public Task Show(string dialogHostId, CancellationTokenSource cancellationTokenSource = null)
		{
			if (_isOpen)
			{
				return _defaultCompletedTask;
			}
			else
			{
				// replace with Interface
				_dialogViewModel.CancellationTokenSource = cancellationTokenSource;
				_isOpen = true;
				return DialogHost.Show(_dialogView, dialogHostId, OnDialogOpened, OnDialogClosing);
			}
		}
		public void Close(bool cancel)
		{
			if (cancel)
			{
				_dialogViewModel.Cancel();
			}
			base.Close();
		}
		public void UpdateDialog(bool cancellable, bool isIndeterminate)
		{
			_dialogViewModel.Cancellable = cancellable;
			_dialogViewModel.IsIndeterminate = isIndeterminate;
		}
		public void UpdateText(string title = null, string supportingText = null)
		{
			_dialogViewModel.Title = title ?? _dialogViewModel.Title;
			_dialogViewModel.SupportingText = supportingText ?? _dialogViewModel.SupportingText;
		}
		public void ShowProgress(double progress, string progressText = null)
		{
			_dialogViewModel.Progress = progress;
			_dialogViewModel.ProgressText = progressText ?? _dialogViewModel.ProgressText;
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
				Title = configuration.Title,
				MaxWidth = configuration.MaxWidth,
				MinWidth = configuration.MinWidth
			};

			_dialogView = new ProgressView()
			{
				DataContext = _dialogViewModel
			};
		}
	}
}
