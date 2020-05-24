using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Framework;
using System.Windows.Media;

namespace MaterialXAMLDialogs
{
	public class ProgressDialogConfiguration : IDialogConfiguration
	{
		public PackIconKind? IconKind { get; set; }
		public Brush IconBrush { get; set; }
		public bool ShowTitleSeparator { get; set; }
		public string SupportingText { get; set; }
		public string Title { get; set; }
		public bool IsIndeterminate { get; set; }
		public bool Cancellable { get; set; }
	}
}
