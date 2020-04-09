// ---------------------------------------------------------------------
// <copyright file="CommonDialogBehavior.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
using System.Windows;
using Microsoft.Win32;

namespace MenuApp2.Views.Behaviors
{
	internal class CommonDialogBehavior
	{
		/// <summary>
		/// Action<bool, string>型の添付プロパティを定義
		/// </summary>
		public static readonly DependencyProperty CallbackProperty =
			DependencyProperty.RegisterAttached(
				"Callback",                     // 添付プロパティの名前
				typeof(Action<bool, string>), // プロパティの型
				typeof(CommonDialogBehavior),  // プロパティの定義されているクラス
				new PropertyMetadata(null, OnCallbackPropertyChanged)  // メタデータ。
							// CallbackPropertyが変更されると、OnCallbackPropertyChangedが実行される。

			);

		// GetXXXとSetXXXが必要。"XXX"はプロパティ名に相当
		public static Action<bool, string> GetCallback(DependencyObject target)
		{
			System.Diagnostics.Debug.WriteLine("CommonDialogBehavior.GetCallback");
			return (Action<bool, string>)target.GetValue(CallbackProperty);
		}
		public static void SetCallback(DependencyObject target, Action<bool, string> value)
		{
			System.Diagnostics.Debug.WriteLine("CommonDialogBehavior.SetCallback");
			target.SetValue(CallbackProperty, value);
		}

		private static void OnCallbackPropertyChanged( 
			DependencyObject sender, 
			DependencyPropertyChangedEventArgs args )
		{
			System.Diagnostics.Debug.WriteLine("CommonDialogBehavior.OnCallbackPropertyChanged");
			Action<bool,string> action = GetCallback( sender );
			if( action != null ) 
			{
				var dlg = new OpenFileDialog()
				{
					Title = "ファイルを開きましょう。",
					Filter = "画像ファイル(*.bmp; *.jpg; *.png)|*.bmp;*.jpg;*.png|すべてのファイル(*.*)|*.*",
					Multiselect = false
				};
				var owner = Window.GetWindow( sender );
				var result = dlg.ShowDialog(owner);

				action(result.Value, dlg.FileName);
			}
			else 
			{
				System.Diagnostics.Debug.WriteLine("Callbackがnull");
			}
		}
	}
}
