// ---------------------------------------------------------------------
// <copyright file="WindowClosingBehavior.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows;

namespace MenuApp5.Views.Behaviors
{
	internal class WindowClosingBehavior
	{
		public static readonly DependencyProperty CallbackProperty =
			DependencyProperty.RegisterAttached(
				"Callback",                     // 添付プロパティの名前
				typeof(Func<bool>), // プロパティの型
				typeof(WindowClosingBehavior),  // プロパティの定義されているクラス
				new PropertyMetadata(null, OnIsEnabledPropertyChanged)  // メタデータ。
																	   // CallbackPropertyが変更されると、OnCallbackPropertyChangedが実行される。
			);
		public static void SetCallback( DependencyObject target, Func<bool> value )
		{
			target.SetValue( CallbackProperty, value );
		}
		public static Func<bool> GetCallback( DependencyObject target )
		{
			return (Func<bool>)target.GetValue(CallbackProperty);
		}

		private static void OnIsEnabledPropertyChanged( DependencyObject sender , DependencyPropertyChangedEventArgs args )
		{
			Window window = sender as Window;
			if (window != null)
			{
				Func<bool> callback = GetCallback(sender);
				if ((callback != null) && (args.OldValue == null))
				{
					window.Closing += OnClosing;
				}
				else if( callback == null )	
				{	
					window.Closing -= OnClosing;
				}
			}
		}

		private static void OnClosing( object sender, CancelEventArgs args )
		{
			
			System.Diagnostics.Debug.WriteLine("WindowClosingBehavior.OnClosing");
			Func<bool> callback = GetCallback( sender as DependencyObject );
			if( callback != null ) 
			{
				args.Cancel = !callback();	// このcallbackはViewModelのOnExit
			}
		}
	}
}
