using SimpleMvvmWpfLib;
using SimpleMvvmWpfLib.WindowEvents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
	public class MainWindowViewModel : BaseViewModel
	{
		public MainWindowViewModel()
		{
		}


		public ObservableCollection<ListItemViewModel> ListItems { get; private set; } =
			new ObservableCollection<ListItemViewModel>();


		private DelegateLoadedAction _testLoadedAction = null;
		public DelegateLoadedAction TestLoadedAction
		{
			get
			{
				return _testLoadedAction ??
					(_testLoadedAction = new DelegateLoadedAction(
						async () =>
						{
							/// test async op
							await Task.Delay(2500);
							TestLabel = "Finished loading";
						}));
			}
		}


		private string _testLabel = "not loaded yet";
		public string TestLabel
		{
			get => _testLabel;
			set => SetPropVal<string>(ref _testLabel, value);
		}


		private bool _canWeClose = false;
		public bool CanWeClose
		{
			get => _canWeClose;
			set => SetPropVal<bool>(ref _canWeClose, value);
		}




		private CanCloseResult _canCloseParameter = new CanCloseResult { Cancel = false };
		public CanCloseResult CanCloseParameter
		{
			get => _canCloseParameter;
			set => SetPropVal<CanCloseResult>(ref _canCloseParameter, value);
		}


		private DelegateCanCloseCheck _testCanCloseCheck = null;
		public DelegateCanCloseCheck TestCanCloseCheck
		{
			get
			{
				return _testCanCloseCheck ??
					(_testCanCloseCheck = new DelegateCanCloseCheck(
						result => result.Cancel = !CanWeClose));
			}
		}
	}
}
