using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MaterialXAMLDialogs.Framework
{
	public class DialogViewModelBase : INotifyPropertyChanged
	{
		public void NotifyOfPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged;

		protected DialogViewModelBase() { }
	}
}
