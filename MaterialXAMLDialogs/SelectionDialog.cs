using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Dialogs;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.Interfaces.DialogViewModels;
using MaterialXAMLDialogs.ViewModels;

namespace MaterialXAMLDialogs
{
	public class SelectionDialog<T> : DialogBase<T>
	{
		// Fields
		private ISelectionViewModel<T> _dialogViewModel;

		// Properties
		public T Result { get; private set; }
		public IEnumerable<T> Items { get; set; }

		// Constructors
		public SelectionDialog(SelectionDialogConfiguration configuration)
		{
			_isOpen = false;
			InitializeDialog(configuration);
		}

		// Methods
		public Task<T> Show(string dialogHosId, IEnumerable<T> items, Func<T, string> displayMemberValue)
		{
			if (_isOpen)
			{
				return _defaultCompletedTask;
			}
			else
			{
				_isOpen = true;
				_dialogViewModel.Items = ConstructItems(items, displayMemberValue);
				return DialogHost.Show(_dialogView, dialogHosId, OnDialogOpened, OnDialogClosing)
					.ContinueWith(t =>
					{
						return Result;
					});
			}
		}

		// Helpers
		private void InitializeDialog(SelectionDialogConfiguration configuration)
		{
			_dialogViewModel = new SelectionViewModel<T>
			{
				Title = configuration.Title,
				ShowTitleSeparator = configuration.ShowTitleSeparator
			};

			_dialogView = new SelectionView
			{
				DataContext = _dialogViewModel
			};
		}
		protected override void OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
		{
			if (eventArgs.Parameter != null)
			{
				Result = (T)eventArgs.Parameter;
			}
			else
			{
				Result = default;
			}
			_isOpen = false;
		}
		private IEnumerable<SelectionItem<T>> ConstructItems(IEnumerable<T> items, Func<T, string> displayMemberValue)
		{
			foreach (var item in items)
			{
				var selectionItem = new SelectionItem<T>
				{
					Item = item,
					DisplayValue = displayMemberValue(item)
				};
				yield return selectionItem;
			}
		}
	}
}
