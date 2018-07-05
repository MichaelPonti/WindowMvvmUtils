using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmWpfLib
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;


		protected virtual void OnPropertyChanged(PropertyChangedEventArgs a)
		{
			PropertyChanged?.Invoke(this, a);
		}


		protected virtual bool SetPropVal<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingField, value))
				return false;

			backingField = value;
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
			return true;
		}
	}
}
