// ---------------------------------------------------------------------
// <copyright file="Person.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
namespace ListApp1.Models
{
	/// <summary>
	/// 人物用データを保持
	/// </summary>
	internal class Person
	{
		// このパターンは prop+tab+tab ですね。
		public string FamilyName { get; set; }
		public string FirstName  { get; set; }
		public string FullName   { get { return this.FamilyName + " " + this.FirstName; } }
		public Gender Gender     { get; set; }
		public int    Age        { get; set; }
		// これは毛色が違うな。！
		public bool   IsAuthenticated { get; set; }

		//public override string ToString()
		//{
		//	return $"{FamilyName} {FirstName} {Gender} {Age} {IsAuthenticated}";
		//}
	}
}
