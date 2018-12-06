using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SimpleMvvmWpfLib.WindowEvents
{
	public class IsVisibilityChangedBindings
	{
		public static readonly DependencyProperty MonitorVisibilityChangedProperty =
			DependencyProperty.RegisterAttached(
				"MonitorVisibility",
				typeof(bool),
				typeof(IsVisibilityChangedBindings),
				new PropertyMetadata(false, new PropertyChangedCallback(OnMonitorVisibilityChangedProperty)));

		public static bool GetMonitorVisibilityChanged(DependencyObject sender) => (bool) sender.GetValue(MonitorVisibilityChangedProperty);
		public static void SetMonitorVisibilityChanged(DependencyObject sender, bool value) => sender.SetValue(MonitorVisibilityChangedProperty, value);

		public static void OnMonitorVisibilityChangedProperty(object sender, DependencyPropertyChangedEventArgs args)
		{
			if (sender is UserControl c)
			{
				bool newEnabled = (bool) args.NewValue;
				bool oldEnabled = (bool) args.OldValue;

				if (oldEnabled && !newEnabled)
					c.IsVisibleChanged -= MyIsVisibleChanged;
				else if (!oldEnabled && newEnabled)
					c.IsVisibleChanged += MyIsVisibleChanged;
			}

		}

		private static void MyIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (sender is UserControl c)
			{
				IVisibilityChanged f = GetVisibilityActionChanged(c);
				if (f != null)
				{
					if ((bool)e.NewValue)
						f.Showing();
					else
						f.Hiding();
				}
			}
		}



		public static readonly DependencyProperty VisibilityActionChangedProperty =
			DependencyProperty.RegisterAttached(
				"VisibilityActionChanged",
				typeof(IVisibilityChanged),
				typeof(IsVisibilityChangedBindings),
				new PropertyMetadata(null));

		public static IVisibilityChanged GetVisibilityActionChanged(DependencyObject sender) => (IVisibilityChanged) sender.GetValue(VisibilityActionChangedProperty);
		public static void SetVisibilityActionChanged(DependencyObject sender, IVisibilityChanged value) => sender.SetValue(VisibilityActionChangedProperty, value);


	}
}
