namespace MaterialXAMLDialogs.Interfaces.DialogConfigurations
{
    public interface IDialogConfiguration
    {
        /// <summary>
        /// Get or Set the Title text to display. 
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Determines whether a separator between the Title and content of the Dialog should be displayed.
        /// </summary>
        bool ShowTitleSeparator { get; set; }
    }
}
