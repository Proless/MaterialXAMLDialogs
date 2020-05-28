using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;

namespace MaterialXAMLDialogs
{
	public class DialogHandler
	{
		// Properties
		public DialogSession Session { get; private set; }
		public object Result { get; private set; }

		// Events
		public event DialogOpenedEventHandler DialogOpened;
		public event DialogClosingEventHandler DialogClosing;

		// Methods
		public Task<object> Show(object content)
		{
			return DialogHost.Show(content, OnDialogOpened, OnDialogClosing);
		}
		public Task<object> Show(object content, object dialogIdentifier)
		{
			return DialogHost.Show(content, dialogIdentifier, OnDialogOpened, OnDialogClosing);
		}

		// Event Handlers
		private void OnDialogClosing(object sender, DialogClosingEventArgs eventArgs)
		{
			Result = eventArgs.Parameter;
			DialogClosing?.Invoke(sender, eventArgs);
		}
		private void OnDialogOpened(object sender, DialogOpenedEventArgs eventArgs)
		{
			Session = eventArgs.Session;
			DialogOpened?.Invoke(sender, eventArgs);
		}
	}
}
