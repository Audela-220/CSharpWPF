// ---------------------------------------------------------------------
// <copyright file="UpperStringViewModel.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpperStringApp1
{
	class UpperStringViewModel
	{
		private string _upperString = "";
		public string UpperString {
			get { return this._upperString; }
			set {
				if (this._upperString != value)
				{
					this._upperString = value;
				}
			}
		}

		private string _inputString = "";
		public string InputString {
			get { return this._inputString; }
			set {
				if (this._inputString != value)
				{
					this._inputString = value;
					this._upperString = this._inputString.ToUpper();
					System.Diagnostics.Debug.WriteLine("UpperString = " + this.UpperString);
				}
			}
		}
	}
}
