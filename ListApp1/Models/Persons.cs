// ---------------------------------------------------------------------
// <copyright file="Persons.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace ListApp1.Models
{
	class Persons
	{
		private List<Person> _list;
		public Persons()
		{
			_list = Enumerable.Range(1, 100).Select(x => new Person()
			{
				FamilyName = "田中",
				FirstName = x.ToString() + "太郎",
				Age = x,
				Gender = (x % 2 == 0 ? Gender.Mail : Gender.Female),
				IsAuthenticated = (x % 3) == 0,
			}).ToList();
		}
		public List<Person> PersonList
		{
			get { return this._list; }
		}

		/// <summary>
		/// 指定されたインデックスのPersonのIsAuthenticatedを返す。
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public bool IsAuthenticated( int index )
		{
			if( this._list == null ) 
			{
				return false;
			}
			Person person = this._list.ElementAt( index );
			if( person != null && person.IsAuthenticated )
			{
				return true;
			}
			return false;
		}
	}
}
