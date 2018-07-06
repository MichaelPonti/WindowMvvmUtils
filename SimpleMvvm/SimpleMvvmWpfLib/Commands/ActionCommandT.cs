using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleMvvmWpfLib.Commands
{
	public class ActionCommand<T> : ActionCommandBase
	{
		private Action<T> _thisExecute = null;
		private Func<T, bool> _thisCanExecute = null;


		public ActionCommand(Action<T> thisExecute, Func<T, bool> thisCanExecute)
		{
			if (thisExecute == null)
				throw new ArgumentNullException(nameof(thisExecute));
			if (thisCanExecute == null)
				throw new ArgumentNullException(nameof(thisCanExecute));

			_thisCanExecute = thisCanExecute;
			_thisExecute = thisExecute;
		}


		public ActionCommand(Action<T> thisExecute)
			: this(thisExecute, (p) => true)
		{
		}

		public void Execute(T parameter)
		{
			_thisExecute(parameter);
		}


		public bool CanExecute(T parameter)
		{
			return _thisCanExecute(parameter);
		}


		protected override bool CanExecute(object parameter)
		{
			return CanExecute((T) parameter);
		}


		protected override void Execute(object parameter)
		{
			Execute((T) parameter);
		}
	}
}
