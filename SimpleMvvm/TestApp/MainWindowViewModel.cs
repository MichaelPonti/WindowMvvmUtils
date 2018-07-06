using SimpleMvvmWpfLib;
using SimpleMvvmWpfLib.Commands;
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
							LoadListItems();
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


		private string _selectionText = null;
		public string SelectionText
		{
			get => _selectionText;
			set => SetPropVal<string>(ref _selectionText, value);
		}


		private ListItemViewModel _selectedListItem = null;
		public ListItemViewModel SelectedListItem
		{
			get => _selectedListItem;
			set
			{
				if (SetPropVal<ListItemViewModel>(ref _selectedListItem, value))
				{
					if (_selectedListItem == null)
					{
						SelectionText = "nothing selected";
					}
					else
					{
						SelectionText = $"{_selectedListItem.Label} -> {_selectedListItem.IsChecked}";
					}

					CommandClearSelectionParameter.RaiseCanExecuteChanged();
				}
			}
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


		private void LoadListItems()
		{
			ListItems.Clear();

			for (int i = 0; i < 15; i++)
			{
				var item = new ListItemViewModel()
				{
					IsChecked = (i % 2 == 0),
					Label = $"My Item {i}",
				};
				ListItems.Add(item);
			}
		}


		private ActionCommand _commandClearSelection = null;
		public ActionCommand CommandClearSelection
		{
			get
			{
				return _commandClearSelection ??
					(_commandClearSelection = new ActionCommand(() => SelectedListItem = null));
			}
		}


		private ActionCommand<ListItemViewModel> _commandClearSelectionParameter = null;
		public ActionCommand<ListItemViewModel> CommandClearSelectionParameter
		{
			get
			{
				return _commandClearSelectionParameter ??
					(_commandClearSelectionParameter = new ActionCommand<ListItemViewModel>(
						(p) =>
						{
							SelectedListItem = null;
						},
						(p) =>
						{
							return (SelectedListItem != null);
						}));
			}
		}
	}
}
