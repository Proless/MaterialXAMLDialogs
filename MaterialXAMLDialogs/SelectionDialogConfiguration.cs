using MaterialXAMLDialogs.Framework;

namespace MaterialXAMLDialogs
{
	public class SelectionDialogConfiguration : IDialogConfiguration
	{
		public string Title { get; set; }
		public bool ShowTitleSeparator { get; set; }
		public string DisplayMemberPath { get; set; }
	}
}
