using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Enums;
using MaterialXAMLDialogs.Interfaces;
using MaterialXAMLDialogs.Interfaces.DialogConfigurations;

namespace MaterialXAMLDialogs
{
	/// <summary>
	/// A configuration class to set the properties of a Dialog.
	/// </summary>
	public class AlertDialogConfiguration : IDialogConfiguration, IDisplayIcon, IDisplaySupportingText
	{
		/// <summary>
		/// The buttons which should be displayed for the user to choose from, they also define the possible DialogResults.
		/// </summary>
		public DialogButtons? DialogButtons { get; set; }

		/// <summary>
		/// Determines whether an additional checkBox should be displayed for the user.
		/// </summary>
		public bool ShowAdditionalOption { get; set; }

		/// <summary>
		/// Determines the default state of the additional CheckBox.
		/// </summary>
		public bool IsAdditionalOptionCheched { get; set; }

		/// <summary>
		/// Get or Set the additional checkBox text.
		/// </summary>
		public string AdditionalOptionText { get; set; }

		public string SupportingText { get; set; }
		public PackIconKind? IconKind { get; set; }
		public Brush IconBrush { get; set; }
		public string Title { get; set; }
		public bool ShowTitleSeparator { get; set; }
		public bool ShowIcon { get; set; }
	}
}
