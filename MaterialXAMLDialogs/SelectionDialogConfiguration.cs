using MaterialXAMLDialogs.Interfaces.DialogConfigurations;

namespace MaterialXAMLDialogs
{
	public class SelectionDialogConfiguration : IDialogConfiguration
	{
		public string Title { get; set; }
		public bool ShowTitleSeparator { get; set; }
	}
}
