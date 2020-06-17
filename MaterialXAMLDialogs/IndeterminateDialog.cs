using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Dialogs;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.Interfaces.DialogViewModels;
using MaterialXAMLDialogs.ViewModels;

namespace MaterialXAMLDialogs
{
	public class IndeterminateDialog : DialogBase<object>
	{
		// Fields
		private IIndeterminateViewModel _dialogViewModel;

		/// <summary>
		/// A dialog to use to show indeterminate progress bar and block the user for interacting with your application.
		/// </summary>
		public IndeterminateDialog()
		{
			_isOpen = false;
		}

		/// <summary>
		/// Shows the dialog.
		/// </summary>
		/// <param name="dialogHostId">The Identifier of the DialogHost instance where the dialog should be shown</param>
		/// <param name="title">The title text to display</param>
		/// <param name="supportingText">The body text to display</param>
		/// <param name="showTitleSeparator">Determines whether a separator between the Title and content of the Dialog should be displayed.</param>
		public Task Show(string dialogHostId, string title, string supportingText, bool showTitleSeparator)
		{
			InitializeDialog(title, supportingText, showTitleSeparator);
			if (_isOpen)
			{
				return _defaultCompletedTask;
			}
			else
			{
				_isOpen = true;
				return DialogHost.Show(_dialogView, dialogHostId, OnDialogOpened, OnDialogClosing);
			}
		}

		/// <summary>
		/// Updates the title and supporting text.
		/// </summary>
		/// <param name="title">The title text to display</param>
		/// <param name="supportingText">The body text to display</param>
		public void UpdateText(string title = null, string supportingText = null)
		{
			_dialogViewModel.Title = title ?? _dialogViewModel.Title;
			_dialogViewModel.SupportingText = supportingText ?? _dialogViewModel.SupportingText;
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

	}
}
