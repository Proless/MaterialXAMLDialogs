using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Interfaces;
using MaterialXAMLDialogs.Interfaces.DialogConfigurations;
using System.Windows.Media;

namespace MaterialXAMLDialogs
{
	/// <summary>
	/// A configuration class to set the properties of a Dialog.
	/// </summary>
	public class ProgressDialogConfiguration : IDialogConfiguration, IDisplayIcon, IDisplaySupportingText
	{
		/// <summary>
		/// Determines the state of the progress bar.
		/// </summary>
		public bool IsIndeterminate { get; set; }

		/// <summary>
		/// Determines whether a Cancel button should displayed for the user to cancel the process.
		/// </summary>
		public bool Cancellable { get; set; }

		/// <summary>
		/// Get or Set the MaxWidth of the dialog.
		/// </summary>
		public double MaxWidth { get; set; } = 520;

		/// <summary>
		/// Get or Set the MinWidth of the dialog.
		/// </summary>
		public double MinWidth { get; set; } = 260;

		public PackIconKind? IconKind { get; set; }
		public Brush IconBrush { get; set; }
		public bool ShowTitleSeparator { get; set; }
		public string SupportingText { get; set; }
		public string Title { get; set; }
		public bool ShowIcon { get; set; }
	}
}
