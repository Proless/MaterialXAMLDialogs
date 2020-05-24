using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Enums;
using MaterialXAMLDialogs.Framework;

namespace MaterialXAMLDialogs.Examples.ViewModels
{
	public class AlertDialogViewModel : ViewModelBase
	{
		// Fields
		private PaletteHelper _paletteHelper;
		private string _result;

		// Properties
		public string Title { get; set; }
		public string SupportingText { get; set; }
		public string AdditionalCheckboxText { get; set; }
		public string Result
		{
			get { return _result; }
			set { _result = value; Notify(); }
		}
		public bool ShowAdditionalCheckbox { get; set; }
		public bool ShowTitleSeparator { get; set; }
		public bool ShowIcon { get; set; }
		public Color IconColor { get; set; }
		public IEnumerable<PackIconKind> Icons { get; set; }
		public IEnumerable<DialogButtons> Buttons { get; set; }
		public PackIconKind SelectedIcon { get; set; }
		public DialogButtons SelectedButtons { get; set; }
		public RelayCommand ShowDialogCommand { get; set; }

		// Constructors
		public AlertDialogViewModel()
		{
			_paletteHelper = new PaletteHelper();
			Title = "Some cool title!";
			SupportingText = "Some details about this alert/notification dialog goes here! You can set the foreground of the icon as well and select any Icon form the PackIcon in MaterialDesignInXamlToolkit";
			AdditionalCheckboxText = "Don't remind me again !";
			ShowAdditionalCheckbox = true;
			ShowTitleSeparator = true;
			ShowIcon = true;
			IconColor = _paletteHelper.GetTheme().SecondaryMid.Color;
			Icons = Enum.GetValues(typeof(PackIconKind)).Cast<PackIconKind>();
			Buttons = Enum.GetValues(typeof(DialogButtons)).Cast<DialogButtons>();
			ShowDialogCommand = new RelayCommand(x => true, ShowDialog);
			SelectedIcon = PackIconKind.Information;
		}

		// Methods
		private async void ShowDialog(object obj)
		{
			var config = new AlertDialogConfiguration
			{
				Title = Title,
				ShowTitleSeparator = ShowTitleSeparator,
				SupportingText = SupportingText,
				DialogButtons = SelectedButtons,
				IconKind = ShowIcon ? SelectedIcon : (PackIconKind?)null,
				IconBrush = new SolidColorBrush(IconColor),
				ShowAdditionalOption = ShowAdditionalCheckbox,
				AdditionalOptionText = AdditionalCheckboxText,
				IsAdditionalOptionCheched = true
			};

			var dialog = new AlertDialog(config);

			var result = await dialog.Show("Root");

			Result = $"{result}, {dialog.AdditionalOptionChecked}";
		}
	}
}
