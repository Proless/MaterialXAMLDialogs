using System.Threading;

namespace MaterialXAMLDialogs.Interfaces.DialogViewModels
{
    internal interface IProgressViewModel : IDialogViewModel, IDisplaySupportingText, IDisplayIcon
    {
        string ProgressText { get; set; }
        double Progress { get; set; }
        bool IsIndeterminate { get; set; }
        bool Cancellable { get; set; }
        CancellationTokenSource CancellationTokenSource { get; set; }
        void Cancel();
    }
}
