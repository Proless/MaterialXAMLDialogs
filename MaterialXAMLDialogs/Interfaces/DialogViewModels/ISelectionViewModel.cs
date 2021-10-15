using MaterialXAMLDialogs.Framework;
using System.Collections.Generic;

namespace MaterialXAMLDialogs.Interfaces.DialogViewModels
{
    internal interface ISelectionViewModel<T> : IDialogViewModel
    {
        IEnumerable<SelectionItem<T>> Items { get; set; }
    }
}
