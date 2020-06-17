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

		/// <summary>
		/// A dialog to show the progress of some operation.
		/// </summary>
		/// <param name="configuration">Configure the look and properties of the dialog</param>
		public ProgressDialog(ProgressDialogConfiguration configuration)
		{
			_isOpen = false;
			InitializeDialog(configuration);
		}

		/// <summary>
		/// Shows the dialog.
		/// </summary>
		/// <param name="dialogHostId">The Identifier of the DialogHost instance where the dialog should be shown</param>
		/// <param name="cancellationTokenSource">A cancellation token to use when the user cancels the operation</param>
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

		/// <summary>
		/// Closes the dialog.
		/// </summary>
		/// <param name="cancel">Determines whether the operation should be canceled when closing this dialog</param>
		public void Close(bool cancel)
		{
			if (cancel)
			{
				_dialogViewModel.Cancel();
			}
			base.Close();
		}

		/// <summary>
		/// Updates the progress bar state and visibility of the Cancel button
		/// </summary>
		/// <param name="cancellable">Determines whether a Cancel button should displayed for the user to cancel the process</param>
		/// <param name="isIndeterminate">Determines the state of the progress bar</param>
		public void UpdateDialog(bool cancellable, bool isIndeterminate)
		{
			_dialogViewModel.Cancellable = cancellable;
			_dialogViewModel.IsIndeterminate = isIndeterminate;
		}

		/// <summary>
		/// Updates the title and supporting text
		/// </summary>
		/// <param name="title">The title text to display</param>
		/// <param name="supportingText">The body text to display</param>
		public void UpdateText(string title = null, string supportingText = null)
		{
			_dialogViewModel.Title = title ?? _dialogViewModel.Title;
			_dialogViewModel.SupportingText = supportingText ?? _dialogViewModel.SupportingText;
		}

		/// <summary>
		/// Updates the progress bar value and the progress text
		/// </summary>
		/// <param name="progress">The value to update the progress bar</param>
		/// <param name="progressText">The progress text, which will be displayed next to the progress bar</param>
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
