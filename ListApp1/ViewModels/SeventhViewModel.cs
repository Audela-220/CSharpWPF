// ---------------------------------------------------------------------
// <copyright file="SeventhViewModel.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System.Collections.ObjectModel;
using ListApp1.Models;
using MVVMLib.ViewModels;

namespace ListApp1.ViewModels
{
    class SeventhViewModel : NotificationObject
    {
		private ObservableCollection<Person> _people;
		private int _count;
		/// <summary>
		/// SeventhViewModelのコンストラクター
		/// _peopleの初期化、_countの初期化
		/// </summary>
		public SeventhViewModel()
		{
			this._people = new ObservableCollection<Person>(); // 空のリストで初期化
			this._count = 0;
		}

		public ObservableCollection<Person> People
		{
			get { return this._people; }
			private set {
				System.Diagnostics.Debug.WriteLine("People.set が呼ばれます。");
				SetProperty(ref this._people, value);
			}
		}

		// Command
		private DelegateCommand _addCommand;
		public DelegateCommand AddCommand {
			get {
				return this._addCommand ?? (this._addCommand = new DelegateCommand(
					_ =>
					{
						this._count++;
						var person = new Person()
						{
							FamilyName = "田中",
							FirstName = this._count.ToString() + "太郎",
							Age = this._count
						};
						this.People.Add(person);
						//this.DellCommand.RaiseCanExecuteChanged(); // DellCommandのCanExecuteのハンドラーが無いので呼ぶ必要なし。
						System.Diagnostics.Debug.WriteLine(person.FullName + "を追加しました。");
					}));
			}
		}

		private DelegateCommand _dellCommand;
		public DelegateCommand DellCommand {
			get {
				return this._dellCommand ?? (this._dellCommand = new DelegateCommand(
					person =>    // Action<object> execute の方, View側で要素を指定してくれるの引数を見ます。
					{
						this.People.Remove( person as Person );			// 指定される要素
						//this.DellCommand.RaiseCanExecuteChanged();	// CanExecuteのハンドラーが無いので呼ぶ必要なし。
					}
				));
			}
		}
	}
}
