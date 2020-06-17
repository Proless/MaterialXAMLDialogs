using System.Windows.Controls;
using MaterialXAMLDialogs.Enums;

namespace MaterialXAMLDialogs.Interfaces.DialogViewModels
{
	internal interface IAlertViewModel : IDialogViewModel, IDisplaySupportingText, IDisplayIcon
	{
		DialogButtons? DialogButtons { get; set; }
		UserControl Buttons { get; set; }
		bool ShowAdditionalOption { get; set; }
		bool IsAdditionalOptionChecked { get; set; }
		string AdditionalOptionText { get; set; }
	}
}
