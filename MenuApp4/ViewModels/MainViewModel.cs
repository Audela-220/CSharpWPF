// ---------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMLib.ViewModels;

namespace MenuApp4.ViewModels
{
	internal class MainViewModel : NotificationObject
	{
		#region ファイルを開く
		private DelegateCommand _openFileCommand;

		public DelegateCommand OpenFileDialog {
			get {
				return this._openFileCommand ?? (
					this._openFileCommand = new DelegateCommand(_ =>
					{
						System.Diagnostics.Debug.WriteLine("ファイルを開きます。");
						this.DialogCallback = OnDialogCallback; // Setするよ。
					}
				));
			}
		}

		private Action<bool, string> _dialogCallback;
		// Viewで実行するときに利用する入れ物
		public Action<bool, string> DialogCallback {
			get {
				System.Diagnostics.Debug.WriteLine("MainViewModel.DialogCallback.Get");
				return this._dialogCallback;
			}
			private set {
				System.Diagnostics.Debug.WriteLine("MainViewModel.DialogCallback.Set");
				SetProperty(ref this._dialogCallback, value);
			}
		}

		private void OnDialogCallback( bool isOk, string filePath )
		{
			this.DialogCallback = null; // 次回実行時に状態が変わるように！nullに変えておく。
			System.Diagnostics.Debug.WriteLine("コールバック処理を行います。");
			System.Diagnostics.Debug.WriteLine("isOK:{0}, filePath:{1}", isOk, filePath);
		}
		#endregion

		public Func<bool> ClosingCallback
		{
			get { return OnExit; }
		}
		private DelegateCommand _exitCommand;
		public DelegateCommand ExitCommand 
		{
			get
			{
				return this._exitCommand ?? ( this._exitCommand = new DelegateCommand(
					_ =>
					{
						OnExit();
					}));
			}
		}
		private int _counter = 0;
		private bool OnExit()
		{
			System.Diagnostics.Debug.WriteLine("OnExit : _counter {0}", this._counter);
			if( this._counter < 3 )
			{
				this._counter++;
				return false;
			}
			App.Current.Shutdown();
			return true;
		}
	}
}
