using MaterialDesignThemes.Wpf;
using System.Windows.Media;

namespace MaterialXAMLDialogs.Framework
{
	public interface IDialogConfiguration
	{
		string Title { get; set; }
		bool ShowTitleSeparator { get; set; }
	}
}
