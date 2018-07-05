using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmWpfLib.WindowEvents
{
	public class DelegateCanCloseCheck : ICanCloseCheck
	{
		public Action<ICanCloseResult> CheckCanCloseAction;

		public DelegateCanCloseCheck(Action<ICanCloseResult> action)
		{
			if (action == null)
				throw new ArgumentNullException("action can't be null", nameof(action));

			CheckCanCloseAction = action;
		}

		protected DelegateCanCloseCheck()
		{
		}


		public void CheckCanClose(ICanCloseResult result)
		{
			CheckCanCloseAction?.Invoke(result);
		}
	}
}
