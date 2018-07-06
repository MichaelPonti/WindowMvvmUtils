using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleMvvmWpfLib.Commands
{
	public class ActionCommand : ActionCommandBase
	{
		private Action _thisExecute = null;
		private Func<bool> _thisCanExecute = null;



		public ActionCommand(Action thisExecute, Func<bool> thisCanExecute)
		{
			if (thisExecute == null)
				throw new ArgumentNullException(nameof(thisExecute));
			if (thisCanExecute == null)
				throw new ArgumentNullException(nameof(thisCanExecute));

			_thisExecute = thisExecute;
			_thisCanExecute = thisCanExecute;
		}


		public ActionCommand(Action thisExecute)
			: this(thisExecute, () => true)
		{
		}


		protected override void Execute(object parameter)
		{
			Execute();
		}


		protected override bool CanExecute(object parameter)
		{
			return CanExecute();
		}


		public void Execute()
		{
			_thisExecute();
		}

		public bool CanExecute()
		{
			return _thisCanExecute();
		}
	}


}
