using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.Interfaces.DialogViewModels;
using System.Threading;
using System.Windows.Media;

namespace MaterialXAMLDialogs.ViewModels
{
    internal class ProgressViewModel : DialogViewModelBase, IProgressViewModel
    {
        // Fields
        private PackIconKind? _iconKind;
        private Brush _iconBrush;
        private string _title;
        private string _supportingText;
        private bool _showTitleSeparator;
        private bool _showIcon;
        private double _progress;
        private string _progressText;
        private bool _isIndeterminate;
        private bool _cancellable;

        // Properties
        public RelayCommand CancelCommand { get; }
        public CancellationTokenSource CancellationTokenSource { get; set; }
        public Brush IconBrush
        {
            get { return _iconBrush; }
            set
            {
                _iconBrush = value;
                if (IconBrush == null)
                {
                    _iconBrush = new SolidColorBrush(Colors.Black);
                }
                NotifyOfPropertyChanged();
            }
        }
        public PackIconKind? IconKind
        {
            get { return _iconKind; }
            set
            {
                if (value == null)
                {
                    _iconKind = 0;
                    ShowIcon = false;
                }
                else
                {
                    _iconKind = value;
                    ShowIcon = true;
                }
                NotifyOfPropertyChanged();
            }
        }
        public bool ShowTitleSeparator
        {
            get { return _showTitleSeparator; }
            set { _showTitleSeparator = value; NotifyOfPropertyChanged(); }
        }
        public bool ShowIcon
        {
            get { return _showIcon; }
            set { _showIcon = value; NotifyOfPropertyChanged(); }
        }
        public bool IsIndeterminate
        {
            get { return _isIndeterminate; }
            set
            { _isIndeterminate = value; NotifyOfPropertyChanged(); }
        }
        public bool Cancellable
        {
            get { return _cancellable; }
            set
            { _cancellable = value; NotifyOfPropertyChanged(); }
        }
        public string SupportingText
        {
            get { return _supportingText; }
            set { _supportingText = value; NotifyOfPropertyChanged(); }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; NotifyOfPropertyChanged(); }
        }
        public string ProgressText
        {
            get { return _progressText; }
            set
            { _progressText = value; NotifyOfPropertyChanged(); }
        }
        public double Progress
        {
            get { return _progress; }
            set
            { _progress = value; NotifyOfPropertyChanged(); }
        }
        public double MaxWidth { get; set; } = 520;
        public double MinWidth { get; set; } = 260;

        //Constructors
        public ProgressViewModel()
        {
            CancelCommand = new RelayCommand(x => true, Cancel);
        }

        // Methods
        public void Cancel()
        {
            CancellationTokenSource?.Cancel();
        }
    }
}
