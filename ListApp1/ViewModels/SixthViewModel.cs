// ---------------------------------------------------------------------
// <copyright file="SixthViewModel.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.ObjectModel;
using ListApp1.Models;
using MVVMLib.ViewModels;

namespace ListApp1.ViewModels
{
    internal class SixthViewModel : NotificationObject
    {
		private ObservableCollection<Person> _people;
		private int _count;
		public SixthViewModel()
		{
			this._people = new ObservableCollection<Person>(); // 空のリストで初期化
			this._count  = 0;
		}

		public ObservableCollection<Person> People // List内の要素の変更をViewへ通知するにはObservableCollection<T>を使いましょう
		{
			get { return this._people; }
			private set {
				System.Diagnostics.Debug.WriteLine("People.set が呼ばれます。");
				SetProperty( ref this._people, value ); 
			}
		}

		// Command
		private DelegateCommand _addCommand;
		public DelegateCommand AddCommand 
		{
			get
			{
				return this._addCommand ?? (this._addCommand = new DelegateCommand (
					_ => 
					{
						this._count++;
						var person = new Person()
						{
							FamilyName = "田中",
							FirstName = this._count.ToString() + "太郎",
							Age = this._count
						};
						this.People.Add( person );
						this.DellCommand.RaiseCanExecuteChanged(); // １個加えたので、DellCommandの実行可能性を更新
						System.Diagnostics.Debug.WriteLine( person.FullName + "を追加しました。");
					}));
			}
		}

		private DelegateCommand	_dellCommand;
		public DelegateCommand DellCommand
		{
			get
			{
				return this._dellCommand ?? ( this._dellCommand = new DelegateCommand(
					_ =>	// Action<object> execute の方
					{
						this.People.RemoveAt( this.People.Count -1 );	// 最後の要素を削除
						this.DellCommand.RaiseCanExecuteChanged();		// １個削除したので、DellCommandの実行可能性を更新
					},
					_ =>	// Func<object,bool> canExecuteの方
					{
						return this.People.Count > 0;
					}
				));
			}
		}
    }
}
