// ---------------------------------------------------------------------
// <copyright file="NinethViewModel.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System.Linq;
using MVVMLib.ViewModels;
using ListApp1.Models;
using System.Collections.ObjectModel;

//ToDo: ModelとViewModelの配置を調整せよ。

namespace ListApp1.ViewModels
{
	internal class NinethViewModel : NotificationObject
	{
		// ここにリストの実体を持ちます。
		private ObservableCollection<Person> _people;
		public NinethViewModel()
		{
			_people = new ObservableCollection < Person >( Enumerable.Range(1, 100).Select(x => new Person()
			{
				FamilyName = "田中",
				FirstName = x.ToString() + "太郎",
				Age = x,
				Gender = (x % 2 == 0 ? Gender.Mail : Gender.Female),
				IsAuthenticated = (x % 3) == 0,
			}).ToList());
		}

		public ObservableCollection<Person> People
		{
			get { return this._people; }
			private set { SetProperty(ref this._people, value); }
		}

		private int _selectedIndex = -1;
		public int SelectedIndex
		{
			get { return this._selectedIndex; }
			set { 

				SetProperty( ref this._selectedIndex, value ); 
				this.DoCommand.RaiseCanExecuteChanged();
			}
		}

		// Command
		private DelegateCommand _doCommand;
		public DelegateCommand DoCommand {
			get {
				return this._doCommand ?? (this._doCommand = new DelegateCommand(
					_ =>
					{
						System.Diagnostics.Debug.WriteLine("Do!");
					},
					_ =>
					{
						if(this.SelectedIndex >= 0 && IsAuthenticated( this.SelectedIndex))
						{
							return true;
						}
						return false;
					}));
			}
		}

		private bool IsAuthenticated( int index )
		{
			if( index > 0 ) 
			{
				Person person = this.People.ElementAt( index );
				if( person != null && person.IsAuthenticated )
				{
					return true;
				}
			}
			return false;
		}

	}
}
