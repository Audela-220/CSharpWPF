// ---------------------------------------------------------------------
// <copyright file="App.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UpperStringApp1
{
	/// <summary>
	/// App.xaml の相互作用ロジック
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			UpperStringView theView = new UpperStringView();
			UpperStringViewModel theViewModel = new UpperStringViewModel();
			theView.DataContext = theViewModel;
			theView.Show();
		}
	}
}
