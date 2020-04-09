using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpperStringApp4
{
	class UpperStringViewModel : NotificationObject
	{
		private string _upperString = "";
		public string UpperString {
			get {
				System.Diagnostics.Debug.WriteLine("UpperString.Get");
				return this._upperString;
			}
			private set {
				System.Diagnostics.Debug.WriteLine("UpperString.Set");
				SetProperty<string>(ref this._upperString, value);
			}
		}

		private string _inputString = "";
		public string InputString {
			get {
				System.Diagnostics.Debug.WriteLine("InputString.Get");
				return this._inputString;
			}
			set {
				System.Diagnostics.Debug.WriteLine("InputString.Set");
				if (SetProperty<string>(ref this._inputString, value))
				{
					this.UpperString = this._inputString.ToUpper();
					this.ClearCommand.RaiseCanExecuteChanged();
					System.Diagnostics.Debug.WriteLine("UpperString = " + this.UpperString);
				}
			}
		}

		// クリアコマンド
		private DelegateCommand _clearCommand;
		public DelegateCommand ClearCommand
		{
			get
			{
				#if FirstCode
				return this._clearCommand ?? (
					this._clearCommand = new DelegateCommand(
						(x) => { this.InputString = ""; },
						(x) => { return string.IsNullOrEmpty( this.InputString ) ? false : true ; }
					)
				);
				#endif
				#if NoDebug
				return this._clearCommand ?? (
						this._clearCommand = new DelegateCommand(
							_ => this.InputString = "",
							_ => !string.IsNullOrEmpty( this.InputString )
						)
					);
				#endif
				if( this._clearCommand == null ) {
					this._clearCommand = new DelegateCommand (
						(_) => {
							System.Diagnostics.Debug.WriteLine("Action - ClearCommand");
							this.InputString = "";
						},
						(_) => {
							bool isNull = string.IsNullOrEmpty( this.InputString );
							return !isNull;
						});
				}
				return this._clearCommand;
			}
		}
	}
}
