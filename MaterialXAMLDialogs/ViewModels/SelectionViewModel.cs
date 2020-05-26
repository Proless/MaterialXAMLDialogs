using System.Collections.Generic;
using MaterialXAMLDialogs.Framework;

namespace MaterialXAMLDialogs.ViewModels
{
	internal class SelectionViewModel<T> : DialogViewModelBase, IDialogViewModel
	{
		// Properties
		public bool ShowTitleSeparator { get; set; }
		public string Title { get; set; }
		public IEnumerable<SelectionItem<T>> Items { get; set; }
	}
}
