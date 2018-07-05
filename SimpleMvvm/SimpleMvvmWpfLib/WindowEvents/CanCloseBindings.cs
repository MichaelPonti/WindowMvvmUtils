using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleMvvmWpfLib.WindowEvents
{
	public class CanCloseBindings
	{
		public static readonly DependencyProperty CanCloseCheckProperty =
			DependencyProperty.RegisterAttached(
				"CanCloseCheck",
				typeof(ICanCloseCheck),
				typeof(CanCloseBindings),
				new PropertyMetadata(null));

		public static ICanCloseCheck GetCanCloseCheck(DependencyObject sender) => (ICanCloseCheck) sender.GetValue(CanCloseCheckProperty);
		public static void SetCanCloseCheck(DependencyObject sender, ICanCloseCheck value) => sender.SetValue(CanCloseCheckProperty, value);


		public static readonly DependencyProperty CanCloseCheckParameterProperty =
			DependencyProperty.RegisterAttached(
				"CanCloseCheckParameter",
				typeof(ICanCloseResult),
				typeof(CanCloseBindings),
				new PropertyMetadata(null));

		public static ICanCloseResult GetCanCloseCheckParameter(DependencyObject sender) => (ICanCloseResult) sender.GetValue(CanCloseCheckParameterProperty);
		public static void SetCanCloseCheckParameter(DependencyObject sender, ICanCloseResult value) => sender.SetValue(CanCloseCheckParameterProperty, value);


		public static readonly DependencyProperty CheckCanCloseEnabledProperty =
			DependencyProperty.RegisterAttached(
				"CheckCanCloseEnabled",
				typeof(bool),
				typeof(CanCloseBindings),
				new PropertyMetadata(false, new PropertyChangedCallback(OnCheckCanClosePropertyChanged)));

		private static void OnCheckCanClosePropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (sender is Window w)
			{
				bool newEnabled = (bool) e.NewValue;
				bool oldEnabled = (bool) e.OldValue;

				if (oldEnabled && !newEnabled)
					w.Closing -= MyOwnWindowClosing;
				else if (!oldEnabled && newEnabled)
					w.Closing += MyOwnWindowClosing;
			}
		}

		public static bool GetCheckCanCloseEnabled(DependencyObject sender) => (bool) sender.GetValue(CheckCanCloseEnabledProperty);
		public static void SetCheckCanCloseEnabled(DependencyObject sender, bool value) => sender.SetValue(CheckCanCloseEnabledProperty, value);

		public static void MyOwnWindowClosing(object sender, CancelEventArgs e)
		{
			ICanCloseCheck q = GetCanCloseCheck((Window) sender);
			ICanCloseResult p = GetCanCloseCheckParameter((Window) sender);
			if (q == null || p == null)
				return;


			q.CheckCanClose(p);
			e.Cancel = p.Cancel;
		}
	}
}
