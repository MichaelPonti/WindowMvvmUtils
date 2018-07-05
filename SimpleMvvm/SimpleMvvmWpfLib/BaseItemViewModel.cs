using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMvvmWpfLib
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class BaseItemViewModel : BaseViewModel
	{
		protected virtual void OnChecked(bool newValue)
		{
		}

		protected virtual void OnExpanded(bool newValue)
		{
		}

		protected virtual void OnSelected(bool newValue)
		{
		}


		#region properties

		private bool _isChecked = false;
		public bool IsChecked
		{
			get => _isChecked;
			set
			{
				if (SetPropVal<bool>(ref _isChecked, value))
					OnChecked(_isChecked);
			}
		}


		private bool _isExpanded = false;
		public bool IsExpanded
		{
			get => _isExpanded;
			set
			{
				if (SetPropVal<bool>(ref _isExpanded, value))
					OnExpanded(_isExpanded);
			}
		}


		private bool _isSelected = false;
		public bool IsSelected
		{
			get => _isSelected;
			set
			{
				if (SetPropVal<bool>(ref _isSelected, value))
					OnSelected(_isSelected);
			}
		}

		#endregion
	}
}
