// ---------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
using MVVMLib.ViewModels;

namespace StyleApp1.ViewModels
{
	internal class MainViewModel : NotificationObject
	{

		#region Sample1
		private DelegateCommand _sample1Command;
		public DelegateCommand Sample1Command
		{
			get 
			{
				return this._sample1Command ?? ( this._sample1Command =
					new DelegateCommand (
						_ => 
						{
							this.Sample1DialogCallback = OnSample1Dialog;
						}
					));
			}
		}
		private Action<bool> _sample1DialogCallback;
		public Action<bool> Sample1DialogCallback
		{
			get { return this._sample1DialogCallback; }
			private set { SetProperty( ref this._sample1DialogCallback, value ); }
		}

		private void OnSample1Dialog( bool result )
		{
			this.Sample1DialogCallback = null;
		}

		private Sample1ViewModel _sample1ViewModel;
		public Sample1ViewModel Sample1
		{
			get { return this._sample1ViewModel ?? (this._sample1ViewModel = new Sample1ViewModel()); }
		}
		#endregion

		#region Sample2
		private DelegateCommand _sample2Command;
		public DelegateCommand Sample2Command {
			get {
				return this._sample2Command ?? (this._sample2Command =
					new DelegateCommand(
						_ =>
						{
							this.Sample2DialogCallback = OnSample2Dialog;
						}
					));
			}
		}
		private Action<bool> _sample2DialogCallback;
		public Action<bool> Sample2DialogCallback {
			get { return this._sample2DialogCallback; }
			private set { SetProperty(ref this._sample2DialogCallback, value); }
		}

		private void OnSample2Dialog(bool result)
		{
			this.Sample2DialogCallback = null;
		}

		private Sample2ViewModel _sample2ViewModel;
		public Sample2ViewModel Sample2 {
			get { return this._sample2ViewModel ?? (this._sample2ViewModel = new Sample2ViewModel()); }
		}
		#endregion

		#region Sample3
		private DelegateCommand _sample3Command;
		public DelegateCommand Sample3Command {
			get {
				return this._sample3Command ?? (this._sample3Command =
					new DelegateCommand(
						_ =>
						{
							this.Sample3DialogCallback = OnSample3Dialog;
						}
					));
			}
		}
		private Action<bool> _sample3DialogCallback;
		public Action<bool> Sample3DialogCallback {
			get { return this._sample3DialogCallback; }
			private set { SetProperty(ref this._sample3DialogCallback, value); }
		}

		private void OnSample3Dialog(bool result)
		{
			this.Sample3DialogCallback = null;
		}

		private Sample3ViewModel _sample3ViewModel;
		public Sample3ViewModel Sample3 {
			get { return this._sample3ViewModel ?? (this._sample3ViewModel = new Sample3ViewModel()); }
		}
		#endregion

		#region Trigger1
		private DelegateCommand _trigger1Command;
		public DelegateCommand Trigger1Command {
			get {
				return this._trigger1Command ?? (this._trigger1Command =
					new DelegateCommand(
						_ =>
						{
							this.Trigger1Callback = OnTrigger1Dialog;
						}
					));
			}
		}
		private Action<bool> _trigger1Callback;
		public Action<bool> Trigger1Callback {
			get { return this._trigger1Callback; }
			private set { SetProperty(ref this._trigger1Callback, value); }
		}

		private void OnTrigger1Dialog(bool result)
		{
			this.Sample3DialogCallback = null;
		}

		private Trigger1ViewModel _trigger1ViewModel;
		public Trigger1ViewModel Trigger1ViewModel {
			get { return this._trigger1ViewModel ?? (this._trigger1ViewModel = new Trigger1ViewModel()); }
		}

		#endregion
		#region Trigger2
		private DelegateCommand _trigger2Command;
		public DelegateCommand Trigger2Command {
			get {
				return this._trigger2Command ?? (this._trigger2Command =
					new DelegateCommand(
						_ =>
						{
							this.Trigger2Callback = OnTrigger2Dialog;
						}
					));
			}
		}
		private Action<bool> _trigger2Callback;
		public Action<bool> Trigger2Callback {
			get { return this._trigger2Callback; }
			private set { SetProperty(ref this._trigger2Callback, value); }
		}

		private void OnTrigger2Dialog(bool result)
		{
			this.Sample3DialogCallback = null;
		}

		private Trigger2ViewModel _trigger2ViewModel;
		public Trigger2ViewModel Trigger2ViewModel {
			get { return this._trigger2ViewModel ?? (this._trigger2ViewModel = new Trigger2ViewModel()); }
		}
		#endregion
		#region Trigger3
		private DelegateCommand _trigger3Command;
		public DelegateCommand Trigger3Command {
			get {
				return this._trigger3Command ?? (this._trigger3Command =
					new DelegateCommand(
						_ =>
						{
							this.Trigger3Callback = OnTrigger3Dialog;
						}
					));
			}
		}
		private Action<bool> _trigger3Callback;
		public Action<bool> Trigger3Callback {
			get { return this._trigger3Callback; }
			private set { SetProperty(ref this._trigger3Callback, value); }
		}

		private void OnTrigger3Dialog(bool result)
		{
			this.Sample3DialogCallback = null;
		}

		private Trigger3ViewModel _trigger3ViewModel;
		public Trigger3ViewModel Trigger3ViewModel {
			get { return this._trigger3ViewModel ?? (this._trigger3ViewModel = new Trigger3ViewModel()); }
		}
		#endregion
		#region Trigger4
		private DelegateCommand _trigger4Command;
		public DelegateCommand Trigger4Command {
			get {
				return this._trigger4Command ?? (this._trigger4Command =
					new DelegateCommand(
						_ =>
						{
							this.Trigger4Callback = OnTrigger4Dialog;
						}
					));
			}
		}
		private Action<bool> _trigger4Callback;
		public Action<bool> Trigger4Callback {
			get { return this._trigger4Callback; }
			private set { SetProperty(ref this._trigger4Callback, value); }
		}

		private void OnTrigger4Dialog(bool result)
		{
			this.Trigger4Callback = null;
		}

		private Trigger4ViewModel _trigger4ViewModel;
		public Trigger4ViewModel Trigger4ViewModel {
			get { return this._trigger4ViewModel ?? (this._trigger4ViewModel = new Trigger4ViewModel()); }
		}
		#endregion
	}
}
