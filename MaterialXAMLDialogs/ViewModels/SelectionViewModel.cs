using System.Collections.Generic;
using MaterialXAMLDialogs.Framework;

namespace MaterialXAMLDialogs.ViewModels
{
	public class SelectionViewModel<T> : DialogViewModelBase, IDialogViewModel
	{
		// Fields
		private string _title;
		private bool _showTitleSeparator;
		private string _displayMemberPath;
		private T _selectedItem;
		private IEnumerable<T> _items;

		// Properties
		public bool ShowTitleSeparator
		{
			get { return _showTitleSeparator; }
			set { _showTitleSeparator = value; Notify(); }
		}
		public string Title
		{
			get { return _title; }
			set { _title = value; Notify(); }
		}
		public IEnumerable<T> Items
		{
			get { return _items; }
			set { _items = value; Notify(); }
		}
		public T SelectedItem
		{
			get { return _selectedItem; }
			set { _selectedItem = value; Notify(); }
		}
		public string DisplayMemberPath
		{
			get { return _displayMemberPath; }
			set { _displayMemberPath = value; Notify(); }
		}
	}
}
