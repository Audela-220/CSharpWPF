// ---------------------------------------------------------------------
// <copyright file="UpperStringViewModel.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System.ComponentModel;

namespace UpperStringApp2
{
	class UpperStringViewModel : INotifyPropertyChanged
	{
		public UpperStringViewModel()
		{
			System.Diagnostics.Debug.WriteLine("UpperStringViewModelのコンストラクタ―");
			PropertyChanged = null; // 明示的に初期化してみましょう。
		}
		private string _upperString = "";
		public string UpperString {
			get 
			{
				System.Diagnostics.Debug.WriteLine("UpperString.Get");
				return this._upperString; 
			}
			set {
				System.Diagnostics.Debug.WriteLine("UpperString.Set");
				if (this._upperString != value)
				{
					this._upperString = value;
					RaisePropertyChanged("UpperString");	// 追加
				}
			}
		}

		private string _inputString = "";
		public string InputString {
			get 
			{
				System.Diagnostics.Debug.WriteLine("InputString.Get");
				return this._inputString; 
			}
			set {
				System.Diagnostics.Debug.WriteLine("InputString.Set");
				if (this._inputString != value)
				{
					this._inputString = value;
					RaisePropertyChanged("InputString");    // 追加
					this.UpperString = this._inputString.ToUpper();
					System.Diagnostics.Debug.WriteLine("UpperString = " + this.UpperString);
				}
			}
		}

		// INotifyPropertyChangedの実装
		public event PropertyChangedEventHandler PropertyChanged;
		private void RaisePropertyChanged( string propertyName )
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if( handler != null )
			{
				System.Diagnostics.Debug.WriteLine("RaisePropertyChanged = " + propertyName);
				handler( this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
