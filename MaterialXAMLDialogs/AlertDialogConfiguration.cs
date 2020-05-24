using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Enums;
using MaterialXAMLDialogs.Framework;
using System.Windows.Media;

namespace MaterialXAMLDialogs
{
	public class AlertDialogConfiguration : IDialogConfiguration
	{
		public DialogButtons? DialogButtons { get; set; }
		public PackIconKind? IconKind { get; set; }
		public Brush IconBrush { get; set; }
		public bool ShowTitleSeparator { get; set; }
		public bool ShowAdditionalOption { get; set; }
		public bool IsAdditionalOptionCheched { get; set; }
		public string AdditionalOptionText { get; set; }
		public string SupportingText { get; set; }
		public string Title { get; set; }
	}
}
