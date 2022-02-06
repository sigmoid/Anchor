using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Anchor.Util
{
	// Taken largely from https://social.msdn.microsoft.com/Forums/sqlserver/en-US/da35a791-a179-4859-a445-a29d74bdc2db/uwphow-do-i-bind-a-ui-event-to-a-method-in-a-viewmodel-class-in-xaml?forum=wpdevelop
	public class AnchorCommand : ICommand
    {
		public event EventHandler CanExecuteChanged;

		private Action _action;

		public AnchorCommand(Action action)
		{
			this._action = action;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			this._action();
		}
		
	}
}
