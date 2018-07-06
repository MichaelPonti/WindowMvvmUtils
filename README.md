# WindowMvvmUtils
This project is a helper library for small WPF-MVVM projects that could benefit with help working with Loaded, Closing and Closed events in their view models, INotifyPropertyChanged, and ICommand support. For those quick and dirty projects that you don't need an entire framework.

## BaseViewModel and BaseItemViewModel
Base view models that implement INotifyPropertyChanged. The BaseItemViewModel can be used with various types of lists and has built in support for check boxes and tree views. Override the virtual methods in the BaseItemViewModel to get notified when the user checks an item or expands a treeview node.

## ActionCommand
Implements ICommand and allows you to pass in functions to execute.

## MVVM Closing and Loaded Window events
Use these attached properties to handle the closing event from the window in your view model. You can stop the window from being closed if desired. Use the Loaded attached properties to handle the window Loaded event in your view model.
