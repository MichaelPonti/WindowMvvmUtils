using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmWpfLib.WindowEvents
{
	public class DelegateLoadedAction : ILoadedAction
	{
		public Action LoadedActionDelegate { get; set; }

		protected DelegateLoadedAction()
		{
		}

		public DelegateLoadedAction(Action action)
		{
			if (action == null)
				throw new ArgumentNullException("action can't be null", nameof(action));

			LoadedActionDelegate = action;
		}


		public void WindowLoaded()
		{
			LoadedActionDelegate?.Invoke();
		}
	}
}
