// ---------------------------------------------------------------------
// <copyright file="CommonDialogBehavior.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
using System.Windows;
using Microsoft.Win32;

namespace MenuApp4.Views.Behaviors
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

		/// <summary>
		/// Callback 添付プロパティを取得する
		/// </summary>
		/// <param name="target"></param>
		/// <returns></returns>
		public static Action<bool, string> GetCallback(DependencyObject target)
		{
			return (Action<bool, string>)target.GetValue(CallbackProperty);
		}
		/// <summary>
		/// Callback添付プロパティを設定する
		/// </summary>
		/// <param name="target"></param>
		/// <param name="value"></param>
		public static void SetCallback(DependencyObject target, Action<bool, string> value)
		{
			target.SetValue(CallbackProperty, value);
		}

		// Title 添付プロパティ
		public static readonly DependencyProperty TitleProperty =
			DependencyProperty.RegisterAttached(
				"Title",                     // 添付プロパティの名前
				typeof(string), // プロパティの型
				typeof(CommonDialogBehavior),  // プロパティの定義されているクラス
				new PropertyMetadata("ファイルを開く")  // メタデータ。
			);
		public static string GetTitle( DependencyObject target )
		{
			return (string)target.GetValue(TitleProperty);
		}
		public static void SetTitle( DependencyObject target, string value )
		{
			target.SetValue( TitleProperty, value );
		}
		// Filter 添付プロパティ
		public static readonly DependencyProperty FilterProperty =
			DependencyProperty.RegisterAttached(
				"Filter",                     // 添付プロパティの名前
				typeof(string), // プロパティの型
				typeof(CommonDialogBehavior),  // プロパティの定義されているクラス
				new PropertyMetadata("すべてのファイル(*.*)|*.*")  // メタデータ。
			);
		public static string GetFilter(DependencyObject target)
		{
			return (string)target.GetValue(FilterProperty);
		}
		public static void SetFilter(DependencyObject target, string value)
		{
			target.SetValue(FilterProperty, value);
		}

		// Multiselect 添付プロパティ
		public static readonly DependencyProperty MultiselectProperty =
			DependencyProperty.RegisterAttached(
				"Multiselect",                     // 添付プロパティの名前
				typeof(bool), // プロパティの型
				typeof(CommonDialogBehavior),  // プロパティの定義されているクラス
				new PropertyMetadata(true)  // メタデータ。
			);
		public static bool GetMultiselect(DependencyObject target)
		{
			return (bool)target.GetValue(MultiselectProperty);
		}
		public static void SetMultiselect(DependencyObject target, string value)
		{
			target.SetValue(MultiselectProperty, value);
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
					Title = GetTitle(sender),
					Filter = GetFilter(sender),
					Multiselect = GetMultiselect(sender)
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
