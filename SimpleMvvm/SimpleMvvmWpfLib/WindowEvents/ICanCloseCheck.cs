using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmWpfLib.WindowEvents
{
	public interface ICanCloseCheck
	{
		void CheckCanClose(ICanCloseResult canCloseResult);
	}
}
