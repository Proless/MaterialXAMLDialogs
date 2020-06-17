using System.Windows.Controls;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Enums;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.Interfaces.DialogViewModels;

namespace MaterialXAMLDialogs.ViewModels
{
	internal class AlertViewModel : DialogViewModelBase, IAlertViewModel
	{
		// Fields
		private DialogButtons? _dialogButtons;
		private PackIconKind? _iconKind;
		private UserControl _buttons;
		private Brush _iconBrush;
		private string _title;
		private string _supportingText;
		private string _additionalOptionText;
		private bool _isAdditionalOptionChecked;
		private bool _showAdditionalOption;
		private bool _showTitleSeparator;
		private bool _showButtons;
		private bool _showIcon;

		// Properties
		public DialogButtons? DialogButtons
		{
			get { return _dialogButtons; }
			set
			{
				_dialogButtons = value;
				if (DialogButtons != null)
				{
					Buttons = ((DialogButtons)DialogButtons).GetButtons();
					ShowButtons = true;
				}
				else
				{
					ShowButtons = false;
				}
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
		public UserControl Buttons
		{
			get { return _buttons; }
			set { _buttons = value; NotifyOfPropertyChanged(); }
		}
		public bool ShowButtons
		{
			get { return _showButtons; }
			private set { _showButtons = value; NotifyOfPropertyChanged(); }
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
		public bool ShowAdditionalOption
		{
			get { return _showAdditionalOption; }
			set { _showAdditionalOption = value; NotifyOfPropertyChanged(); }
		}
		public bool IsAdditionalOptionChecked
		{
			get { return _isAdditionalOptionChecked; }
			set { _isAdditionalOptionChecked = value; NotifyOfPropertyChanged(); }
		}
		public string AdditionalOptionText
		{
			get { return _additionalOptionText; }
			set { _additionalOptionText = value; NotifyOfPropertyChanged(); }
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
	}
}
