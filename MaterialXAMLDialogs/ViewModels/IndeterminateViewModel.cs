using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.Interfaces.DialogViewModels;

namespace MaterialXAMLDialogs.ViewModels
{
	internal class IndeterminateViewModel : DialogViewModelBase, IIndeterminateViewModel
	{
		// Fields
		private string _title;
		private bool _showTitleSeparator;
		private string _supportingText;

		// Properties
		public string Title
		{
			get { return _title; }
			set { _title = value; NotifyOfPropertyChanged(); }
		}
		public bool ShowTitleSeparator
		{
			get { return _showTitleSeparator; }
			set { _showTitleSeparator = value; NotifyOfPropertyChanged(); }
		}
		public string SupportingText
		{
			get { return _supportingText; }
			set { _supportingText = value; NotifyOfPropertyChanged(); }
		}
	}
}
