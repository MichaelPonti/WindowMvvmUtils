using SimpleMvvmWpfLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
	public class ListItemViewModel : BaseItemViewModel
	{
		public ListItemViewModel()
		{
		}

		private string _label = null;
		public string Label
		{
			get => _label;
			set => SetPropVal<string>(ref _label, value);
		}


		protected override void OnChecked(bool newValue)
		{
			base.OnChecked(newValue);
			Debug.WriteLine($"Checked Value {newValue}");
		}
	}
}
