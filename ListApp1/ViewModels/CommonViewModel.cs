// ---------------------------------------------------------------------
// <copyright file="CommonViewModel.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System.Collections.Generic;
using MVVMLib.ViewModels;
using ListApp1.Models;

namespace ListApp1.ViewModels
{
	class CommonViewModel : NotificationObject
	{
		private Persons _persons;

		public CommonViewModel()
		{
			_persons = new Persons();
			this.People = _persons.PersonList;
		}

		private List<Person> _people;
		public List<Person> People {
			get { return this._people; }
			private set { SetProperty(ref this._people, value); }
		}

	}
}
