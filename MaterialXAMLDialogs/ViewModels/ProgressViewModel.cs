using System.Threading;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Framework;

namespace MaterialXAMLDialogs.ViewModels
{
	internal class ProgressViewModel : DialogViewModelBase, IDialogViewModel
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
		public DialogSession Session { get; set; }
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
				Notify();
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
				Notify();
			}
		}
		public bool ShowTitleSeparator
		{
			get { return _showTitleSeparator; }
			set { _showTitleSeparator = value; Notify(); }
		}
		public bool ShowIcon
		{
			get { return _showIcon; }
			private set { _showIcon = value; Notify(); }
		}
		public bool IsIndeterminate
		{
			get { return _isIndeterminate; }
			set
			{ _isIndeterminate = value; Notify(); }
		}
		public bool Cancellable
		{
			get { return _cancellable; }
			set
			{ _cancellable = value; Notify(); }
		}
		public string SupportingText
		{
			get { return _supportingText; }
			set { _supportingText = value; Notify(); }
		}
		public string Title
		{
			get { return _title; }
			set { _title = value; Notify(); }
		}
		public string ProgressText
		{
			get { return _progressText; }
			set
			{ _progressText = value; Notify(); }
		}
		public double Progress
		{
			get { return _progress; }
			set
			{ _progress = value; Notify(); }
		}

		//Constructors
		public ProgressViewModel()
		{
			CancelCommand = new RelayCommand(x => true, Cancel);
		}

		// Methods
		public void Cancel(object obj)
		{
			CancellationTokenSource?.Cancel();
			Session?.Close();
		}
	}
}
