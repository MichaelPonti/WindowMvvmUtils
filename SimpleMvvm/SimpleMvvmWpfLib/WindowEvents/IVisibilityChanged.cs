﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmWpfLib.WindowEvents
{
	public interface IVisibilityChanged
	{
		void Showing();
		void Hiding();
	}
}