using System.Collections.Generic;
using MaterialXAMLDialogs.Framework;

namespace MaterialXAMLDialogs.Interfaces.DialogViewModels
{
	internal interface ISelectionViewModel<T> : IDialogViewModel
	{
		IEnumerable<SelectionItem<T>> Items { get; set; }
	}
}
