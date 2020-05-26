using System;
using System.Collections.Generic;
using MaterialXAMLDialogs.Framework;

namespace MaterialXAMLDialogs.Examples.ViewModels
{
	public class SelectionDialogViewModel : ViewModelBase
	{
		// Fields
		private string _result;

		// Properties
		public string Title { get; set; }
		public string ItemsText { get; set; }
		public string Result
		{
			get { return _result; }
			set { _result = value; Notify(); }
		}
		public bool ShowTitleSeparator { get; set; }
		public RelayCommand ShowDialogCommand { get; set; }
		public IEnumerable<string> Items { get; set; }

		public SelectionDialogViewModel()
		{
			Title = "Some title that is not ambiguous!";
			ShowTitleSeparator = true;
			ItemsText = "Item0\nItem1\nItem2\nItem3\nItem4\nItem5\nItem6\nItem7\nThe Selection Dialog\naccepts an IEnumerable<T>\nand you must pass in a Func<T,string>\nto detemine the display value.";
			ShowDialogCommand = new RelayCommand(x => true, ShowDialog);
		}

		private async void ShowDialog(object obj)
		{

			Items = ItemsText.Split('\n', StringSplitOptions.RemoveEmptyEntries);


			var config = new SelectionDialogConfiguration
			{
				ShowTitleSeparator = ShowTitleSeparator,
				Title = Title
			};

			var dialog = new SelectionDialog<string>(config);

			var selectedItem = await dialog.Show("Root", Items, (s) => s);

			Result = $"Selected Item: {selectedItem}";
		}
	}
}
