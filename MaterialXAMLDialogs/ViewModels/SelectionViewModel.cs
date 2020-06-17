using System.Collections.Generic;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.Interfaces.DialogViewModels;

namespace MaterialXAMLDialogs.ViewModels
{
	internal class SelectionViewModel<T> : DialogViewModelBase, ISelectionViewModel<T>
	{
		// Properties
		public bool ShowTitleSeparator { get; set; }
		public string Title { get; set; }
		public IEnumerable<SelectionItem<T>> Items { get; set; }
	}
}
