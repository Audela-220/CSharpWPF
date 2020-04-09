// ---------------------------------------------------------------------
// <copyright file="VersionViewModel.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMLib.ViewModels;
using MenuApp5.Models;

namespace MenuApp5.ViewModels
{
	class VersionViewModel : NotificationObject
	{
		#region Properties
		public string Title 
		{
			get
			{
				return ProductInfo.Title;
			}
		}
		public string ProductName
		{
			get
			{
				return ProductInfo.ProductName;
			}
		}

		public string Version
		{
			get
			{
				return "Ver." + ProductInfo.VersionString;
			}
		}
		public string Copyright
		{
			get
			{
				return ProductInfo.Copyright; 
			}
		}
		#endregion
		private bool _closeWindow;
		public bool CloseWindow
		{
			get { return this._closeWindow; }
			set { 
				this.SetProperty(ref this._closeWindow, value); 
				if( this.CloseWindow ) {
					this.SetProperty(ref this._closeWindow, false);
				}
			}
		}

		public DelegateCommand _closeCommand;
		public DelegateCommand CloseCommand
		{
			get { return _closeCommand ?? (_closeCommand = new DelegateCommand(
				_ =>
				{
					System.Diagnostics.Debug.WriteLine("View -> ViewModel (CloseCommand)");
					this.CloseWindow = true;
				}));
			}
		}

	}

}
