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

		// Constructors
		public IndeterminateDialog()
		{
			_isOpen = false;
		}

		// Methods
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
		public void Update(string title = null, string supportingText = null)
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
