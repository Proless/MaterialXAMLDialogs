using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MaterialXAMLDialogs.Examples.ViewModels
{
	public class ViewModelBase : INotifyPropertyChanged
	{
		public void Notify([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		public event PropertyChangedEventHandler PropertyChanged;
	}
}
