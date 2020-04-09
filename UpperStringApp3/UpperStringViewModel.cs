// ---------------------------------------------------------------------
// <copyright file="UpperStringViewModel.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

namespace UpperStringApp3
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
				SetProperty<string>( ref this._upperString, value );
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
				if (SetProperty<string>( ref this._inputString, value ) )
				{
					this.UpperString = this._inputString.ToUpper();
					System.Diagnostics.Debug.WriteLine("UpperString = " + this.UpperString);
				}
			}
		}
	}
}
