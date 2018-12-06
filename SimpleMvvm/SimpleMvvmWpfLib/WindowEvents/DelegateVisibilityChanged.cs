using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmWpfLib.WindowEvents
{
	public class DelegateVisibilityChanged : IVisibilityChanged
	{
		public Action HidingDelegate { get; set; } = null;
		public Action ShowingDelegate { get; set; } = null;


		public DelegateVisibilityChanged()
		{
		}

		public DelegateVisibilityChanged(Action showing, Action hiding)
		{
			HidingDelegate = hiding;
			ShowingDelegate = showing;
		}


		public void Hiding()
		{
			if (HidingDelegate != null)
				HidingDelegate();
		}

		public void Showing()
		{
			if (ShowingDelegate != null)
				ShowingDelegate();
		}
	}
}
