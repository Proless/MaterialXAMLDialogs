using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace MaterialXAMLDialogs.Interfaces
{
	internal interface IDisplayIcon
	{
		Brush IconBrush { get; set; }
		PackIconKind? IconKind { get; set; }
		bool ShowIcon { get; set; }
	}
}
