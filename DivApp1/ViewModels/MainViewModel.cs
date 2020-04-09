// ---------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------
using System;
using MVVMLib.ViewModels;
using DivApp1.Models;
namespace DivApp1.ViewModels
{
	internal class MainViewModel : NotificationObject
	{
		private Calculator _calc;
		public MainViewModel()
		{
			this._calc = new Calculator();
		}

		private string _lhs; // left hand side
		public string Lhs
		{
			get { return this._lhs; }
			set 
			{
				if( SetProperty<string>( ref this._lhs, value ) )
				{
					this.DivCommand.RaiseCanExecuteChanged();
				}
			}
		}

		private string _rhs; // right hand side
		public string Rhs
		{
			get { return this._rhs; }
			set 
			{ 
				if( SetProperty<string>(ref this._rhs, value))
				{
					this.DivCommand.RaiseCanExecuteChanged();
				}
			}
		}

		private string _result;
		public string Result
		{
			get { return this._result; }
			set { SetProperty<string>( ref this._result, value ); }
		}

		private DelegateCommand _divCommand;
		public DelegateCommand DivCommand 
		{
			get 
			{
				return this._divCommand ?? ( this._divCommand = new DelegateCommand(
					_ =>
					{	
						OnDivision();
					},
					_ =>
					{
						double tempDouble = 0.0; // 仮の入れ物。TryParseを実行するのに必要。
						if (!double.TryParse(this.Lhs, out tempDouble))
						{
							return false;
						}
						if (!double.TryParse(this.Rhs, out tempDouble))
						{
							return false;
						}
						return true;
					}
					));
			}
		}

		private void OnDivision()
		{
			this._calc.Lhs = double.Parse(this.Lhs);
			this._calc.Rhs = double.Parse(this.Rhs);
			this._calc.ExecuteDiv();
			this.Result = this._calc.Result.ToString();
		}
	}
}
