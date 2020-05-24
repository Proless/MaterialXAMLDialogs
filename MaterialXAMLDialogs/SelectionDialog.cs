using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using MaterialXAMLDialogs.Dialogs;
using MaterialXAMLDialogs.Framework;
using MaterialXAMLDialogs.ViewModels;

namespace MaterialXAMLDialogs
{
	public class SelectionDialog<T>
	{
		// Fields
		private static readonly Task<T> _completedTask = Task.FromResult(default(T));
		private UserControl _dialogView;
		private IDialogViewModel _dialogViewModel;
		private DialogSession _dialogSession;
		private bool _isOpen;

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
		public Task<T> Show(string dialogHosId, IEnumerable<T> items, string displayMemberPath)
		{
			if (_isOpen)
			{
				return _completedTask;
			}
			else
			{
				_isOpen = true;
				// replace with interface 
				(_dialogViewModel as SelectionViewModel<T>).DisplayMemberPath = displayMemberPath;
				(_dialogViewModel as SelectionViewModel<T>).Items = items;
				return DialogHost.Show(_dialogView, dialogHosId, OnDialogOpened, OnDialogClosing)
					.ContinueWith(t =>
					{
						return Result;
					});
			}
		}
		public void Close()
		{
			if (_dialogSession != null && !_dialogSession.IsEnded)
			{
				_dialogSession?.Close();
			}
			_isOpen = false;
		}

		// Helpers
		private void InitializeDialog(SelectionDialogConfiguration configuration)
		{
			_dialogViewModel = new SelectionViewModel<T>
			{
				DisplayMemberPath = configuration.DisplayMemberPath,
				Title = configuration.Title,
				ShowTitleSeparator = configuration.ShowTitleSeparator
			};

			_dialogView = new SelectionView
			{
				DataContext = _dialogViewModel
			};
		}
		private void OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
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
		private void OnDialogOpened(object sender, DialogOpenedEventArgs eventArgs)
		{
			_dialogSession = eventArgs.Session;
		}
	}
}
