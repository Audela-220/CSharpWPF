// ---------------------------------------------------------------------
// <copyright file="TopViewModel.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
using MVVMLib.ViewModels;

namespace ListApp1.ViewModels
{
	internal class TopViewModel : NotificationObject
	{
		#region FirstView
		// First View (図6.1）
		private DelegateCommand _firstViewCommand;
		public DelegateCommand FirstViewCommand {
			get {
				return this._firstViewCommand ?? (this._firstViewCommand =
					new DelegateCommand(
						_ =>
						{
							this.FirstViewCallback = OnFirstView;
						}
					));
			}
		}
		private Action<bool> _firstViewCallback;
		public Action<bool> FirstViewCallback {
			get { return this._firstViewCallback; }
			private set { SetProperty(ref this._firstViewCallback, value); }
		}

		private void OnFirstView(bool result)
		{
			this.FirstViewCallback = null;
		}

		private FirstViewModel _firstViewModel;
		public FirstViewModel FirstViewModel {
			get { return this._firstViewModel ?? (this._firstViewModel = new FirstViewModel()); }
		}
		#endregion
		#region SecondView
		// Second View (図6.2）
		private DelegateCommand _secondViewCommand;
		public DelegateCommand SecondViewCommand {
			get {
				return this._secondViewCommand ?? (this._secondViewCommand =
					new DelegateCommand(
						_ =>
						{
							this.SecondViewCallback = OnSecondView;
						}
					));
			}
		}
		private Action<bool> _secondViewCallback;
		public Action<bool> SecondViewCallback {
			get { return this._secondViewCallback; }
			private set { SetProperty(ref this._secondViewCallback, value); }
		}

		private void OnSecondView(bool result)
		{
			this.SecondViewCallback = null;
		}

		private SecondViewModel _secondViewModel;
		public SecondViewModel SecondViewModel {
			get { return this._secondViewModel ?? (this._secondViewModel = new SecondViewModel()); }
		}
		#endregion
		#region ThirdView
		// Third View スクロールバーあり
		private DelegateCommand _thirdViewCommand;
		public DelegateCommand ThirdViewCommand {
			get {
				return this._thirdViewCommand ?? (this._thirdViewCommand =
					new DelegateCommand(
						_ =>
						{
							this.ThirdViewCallback = OnThirdView;
						}
					));
			}
		}
		private Action<bool> _thirdViewCallback;
		public Action<bool> ThirdViewCallback {
			get { return this._thirdViewCallback; }
			private set { SetProperty(ref this._thirdViewCallback, value); }
		}

		private void OnThirdView(bool result)
		{
			this.ThirdViewCallback = null;
		}

		private ThirdViewModel _thirdViewModel;
		public ThirdViewModel ThirdViewModel {
			get { return this._thirdViewModel ?? (this._thirdViewModel = new ThirdViewModel()); }
		}
		#endregion
		#region FourthView
		// Fourth View / Listbox カスタマイズ
		private DelegateCommand _fourthViewCommand;
		public DelegateCommand FourthViewCommand {
			get {
				return this._fourthViewCommand ?? (this._fourthViewCommand =
					new DelegateCommand(
						_ =>
						{
							this.FourthViewCallback = OnFourthView;
						}
					));
			}
		}
		private Action<bool> _fourthViewCallback;
		public Action<bool> FourthViewCallback {
			get { return this._fourthViewCallback; }
			private set { SetProperty(ref this._fourthViewCallback, value); }
		}

		private void OnFourthView(bool result)
		{
			this.FourthViewCallback = null;
		}

		private FourthViewModel _fourthViewModel;
		public FourthViewModel FourthViewModel {
			get { return this._fourthViewModel ?? (this._fourthViewModel = new FourthViewModel()); }
		}
		#endregion
		#region FifthView
		// Fifth View / ComboBox カスタマイズ
		private DelegateCommand _fifthViewCommand;
		public DelegateCommand FifthViewCommand {
			get {
				return this._fifthViewCommand ?? (this._fifthViewCommand =
					new DelegateCommand(
						_ =>
						{
							this.FifthViewCallback = OnFifthView;
						}
					));
			}
		}
		private Action<bool> _fifthViewCallback;
		public Action<bool> FifthViewCallback {
			get { return this._fifthViewCallback; }
			private set { SetProperty(ref this._fifthViewCallback, value); }
		}

		private void OnFifthView(bool result)
		{
			this.FifthViewCallback = null;
		}

		private FifthViewModel _fifthViewModel;
		public FifthViewModel FifthViewModel {
			get { return this._fifthViewModel ?? (this._fifthViewModel = new FifthViewModel()); }
		}
		#endregion
		#region SixthView
		// Sixth View / ListBox/add,del 
		private DelegateCommand _sixthViewCommand;
		public DelegateCommand SixthViewCommand {
			get {
				return this._sixthViewCommand ?? (this._sixthViewCommand =
					new DelegateCommand(
						_ =>
						{
							this.SixthViewCallback = OnSixthView;
						}
					));
			}
		}
		private Action<bool> _sixthViewCallback;
		public Action<bool> SixthViewCallback {
			get { return this._sixthViewCallback; }
			private set { SetProperty(ref this._sixthViewCallback, value); }
		}

		private void OnSixthView(bool result)
		{
			this.SixthViewCallback = null;
		}

		private SixthViewModel _sixthViewModel;
		public SixthViewModel SixthViewModel {
			get { return this._sixthViewModel ?? (this._sixthViewModel = new SixthViewModel()); }
		}
		#endregion
		#region SeventhView
		// Seventh View / ListBox/add,del 
		private DelegateCommand _seventhViewCommand;
		public DelegateCommand SeventhViewCommand {
			get {
				return this._seventhViewCommand ?? (this._seventhViewCommand =
					new DelegateCommand(
						_ =>
						{
							this.SeventhViewCallback = OnSeventhView;
						}
					));
			}
		}
		private Action<bool> _seventhViewCallback;
		public Action<bool> SeventhViewCallback {
			get { return this._seventhViewCallback; }
			private set { SetProperty(ref this._seventhViewCallback, value); }
		}

		private void OnSeventhView(bool result)
		{
			this.SeventhViewCallback = null;
		}

		private SeventhViewModel _seventhViewModel;
		public SeventhViewModel SeventhViewModel {
			get { return this._seventhViewModel ?? (this._seventhViewModel = new SeventhViewModel()); }
		}
		#endregion
		#region EighthView
		// Eigth View 
		private DelegateCommand _eighthViewCommand;
		public DelegateCommand EighthViewCommand {
			get {
				return this._eighthViewCommand ?? (this._eighthViewCommand =
					new DelegateCommand(
						_ =>
						{
							this.EighthViewCallback = OnEighthView;
						}
					));
			}
		}
		private Action<bool> _eighthViewCallback;
		public Action<bool> EighthViewCallback {
			get { return this._eighthViewCallback; }
			private set { SetProperty(ref this._eighthViewCallback, value); }
		}

		private void OnEighthView(bool result)
		{
			this.EighthViewCallback = null;
		}

		private EighthViewModel _eighthViewModel;
		public EighthViewModel EighthViewModel {
			get { return this._eighthViewModel ?? (this._eighthViewModel = new EighthViewModel()); }
		}
		#endregion
		#region NinethView
		// Eigth View 
		private DelegateCommand _ninethViewCommand;
		public DelegateCommand NinethViewCommand {
			get {
				return this._ninethViewCommand ?? (this._ninethViewCommand =
					new DelegateCommand(
						_ =>
						{
							this.NinethViewCallback = OnNinethView;
						}
					));
			}
		}
		private Action<bool> _ninethViewCallback;
		public Action<bool> NinethViewCallback {
			get { return this._ninethViewCallback; }
			private set { SetProperty(ref this._ninethViewCallback, value); }
		}

		private void OnNinethView(bool result)
		{
			this.NinethViewCallback = null;
		}

		private NinethViewModel _ninethViewModel;
		public NinethViewModel NinethViewModel {
			get { return this._ninethViewModel ?? (this._ninethViewModel = new NinethViewModel()); }
		}
		#endregion

	}
}
