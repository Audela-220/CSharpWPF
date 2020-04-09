using System;
using System.Windows.Input;

namespace UpperStringApp4
{
	internal class DelegateCommand : ICommand
	{
		private Action<object> _execute;

		private Func<object, bool> _canExecute;

		public DelegateCommand( Action<object> execute ) : this( execute, null ){ }
		public DelegateCommand( Action<object> execute, Func<object, bool> canExecute )
		{
			this._execute = execute;
			this._canExecute = canExecute;
		}

		public bool CanExecute( object parameter )
		{
			return ( this._canExecute != null ? this._canExecute(parameter) : true );
		}

		public event EventHandler CanExecuteChanged;

		public void RaiseCanExecuteChanged()
		{
			EventHandler handler = this.CanExecuteChanged;
			if( handler != null )
			{
				handler( this, EventArgs.Empty );
			}
		}

		public void Execute( object parameter )
		{
			if( this._execute != null ) 
			{
				this._execute( parameter );
			}
		}
	}
}
