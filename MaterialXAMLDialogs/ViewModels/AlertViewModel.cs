using System.Windows.Controls;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Enums;
using MaterialXAMLDialogs.Framework;

namespace MaterialXAMLDialogs.ViewModels
{
	internal class AlertViewModel : DialogViewModelBase, IDialogViewModel
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
				Notify();
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
				Notify();
			}
		}
		public UserControl Buttons
		{
			get { return _buttons; }
			private set { _buttons = value; Notify(); }
		}
		public bool ShowButtons
		{
			get { return _showButtons; }
			private set { _showButtons = value; Notify(); }
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
		public bool ShowAdditionalOption
		{
			get { return _showAdditionalOption; }
			set { _showAdditionalOption = value; Notify(); }
		}
		public bool IsAdditionalOptionChecked
		{
			get { return _isAdditionalOptionChecked; }
			set { _isAdditionalOptionChecked = value; Notify(); }
		}
		public string AdditionalOptionText
		{
			get { return _additionalOptionText; }
			set { _additionalOptionText = value; Notify(); }
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
	}
}
