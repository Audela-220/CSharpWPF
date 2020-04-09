// ---------------------------------------------------------------------
// <copyright file="Calculator.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivApp1.Models
{
	internal class Calculator
	{
		public double Lhs { get; set; } = 0.0;
		public double Rhs { get; set; } = 0.0;

		public double Result { get; private set; } = 0.0;

		public void ExecuteDiv()
		{
			this.Result = this.Lhs / this.Rhs;
		}
	}
}
