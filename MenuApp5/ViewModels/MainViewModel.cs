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
using System.Timers;

namespace MenuApp5.ViewModels
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

		#region アプリケーションを終了する
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
						if(OnExit()) 
						{
							App.Current.Shutdown();
						}
					}));
			}
		}
		//private int _counter = 0;
		private bool OnExit()
		{
			System.Diagnostics.Debug.WriteLine("MainViewModel.OnExit");
			//System.Diagnostics.Debug.WriteLine("OnExit : _counter {0}", this._counter);
			//if( this._counter < 3 )
			//{
			//	this._counter++;
			//	return false;
			//}
			//App.Current.Shutdown();
			return true;
		}
		#endregion

		private VersionViewModel _versionViewModel = new VersionViewModel();
		public VersionViewModel VersionViewModel
		{
			get 
			{
				System.Diagnostics.Debug.WriteLine("VersionViewModel.Get");
				return this._versionViewModel; 
			}
		}
		private DelegateCommand _versionDialogCommand;
		public DelegateCommand VersionDialogCommand 
		{
			get
			{
				return this._versionDialogCommand ?? (this._versionDialogCommand =
					new DelegateCommand(
						_ => 
						{
							this.VersionDialogCallback = OnVersionDialog;
						}
					));
			}
		}

		private Action<bool> _versionDialogCallback;
		public Action<bool> VersionDialogCallback
		{
			get { return this._versionDialogCallback; }
			private set { SetProperty( ref this._versionDialogCallback, value ); }
		}

		private void OnVersionDialog( bool result )
		{
			this.VersionDialogCallback = null;
			System.Diagnostics.Debug.WriteLine( "MainViewModel.OnVersionDialog : " + result );
		}

		// 現在時刻
		private Timer _timer;
		private DateTime _currentTime;

		public DateTime CurrentTime
		{
			get 
			{
				if( this._timer == null )
				{
					this._currentTime = DateTime.Now;
					this._timer = new Timer(1000);
					this._timer.Elapsed += ( _, __) =>
					{
						this.CurrentTime = DateTime.Now;
					};
					this._timer.Start();
				}
				return this._currentTime;
			}
			private set 
			{
				//System.Diagnostics.Debug.WriteLine("MainViewModel.CurrentTime.Set");
				SetProperty( ref this._currentTime, value );
			}
		}
	}
}
