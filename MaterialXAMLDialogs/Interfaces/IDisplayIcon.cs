using MaterialDesignThemes.Wpf;
using System.Windows.Media;

namespace MaterialXAMLDialogs.Interfaces
{
    internal interface IDisplayIcon
    {
        /// <summary>
        /// The Icon brush color.
        /// </summary>
        Brush IconBrush { get; set; }

        /// <summary>
        /// The Icon kind to display.
        /// </summary>
        PackIconKind? IconKind { get; set; }

        /// <summary>
        /// Determines the visibility of the icon. 
        /// </summary>
        bool ShowIcon { get; set; }
    }
}
