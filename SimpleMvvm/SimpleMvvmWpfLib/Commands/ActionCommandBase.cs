using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleMvvmWpfLib.Commands
{
	public abstract class ActionCommandBase : ICommand
	{
		public virtual event EventHandler CanExecuteChanged;


		protected ActionCommandBase()
		{
		}

		protected virtual void OnCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, EventArgs.Empty);
		}

		public void RaiseCanExecuteChanged()
		{
			OnCanExecuteChanged();
		}


		void ICommand.Execute(object parameter)
		{
			Execute(parameter);
		}

		bool ICommand.CanExecute(object parameter)
		{
			return CanExecute(parameter);
		}


		protected abstract void Execute(object parameter);

		protected abstract bool CanExecute(object parameter);
	}
}
