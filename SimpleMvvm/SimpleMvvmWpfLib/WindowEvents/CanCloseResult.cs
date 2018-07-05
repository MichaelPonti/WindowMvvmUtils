using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmWpfLib.WindowEvents
{
	public class CanCloseResult : ICanCloseResult
	{
		public bool Cancel { get; set; }
	}
}
