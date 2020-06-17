using MaterialXAMLDialogs.Interfaces.DialogConfigurations;

namespace MaterialXAMLDialogs
{
	/// <summary>
	/// A configuration class to set the properties of a Dialog.
	/// </summary>
	public class SelectionDialogConfiguration : IDialogConfiguration
	{
		public string Title { get; set; }
		public bool ShowTitleSeparator { get; set; }
	}
}
