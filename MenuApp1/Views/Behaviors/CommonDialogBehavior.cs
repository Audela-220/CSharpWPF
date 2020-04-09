// ---------------------------------------------------------------------
// <copyright file="CommonDialogBehavior.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
using System.Windows;

namespace MenuApp1.Views.Behaviors
{
	internal class CommonDialogBehavior
	{
		// 添付プロパティを作成する。
		// DependencyProperty.RegisterAttached を使います。
		public static readonly DependencyProperty CallbackProperty =
			DependencyProperty.RegisterAttached(
				"Callback",						// 添付プロパティの名前
				typeof( Action<bool, string> ), // プロパティの型
				typeof( CommonDialogBehavior),  // プロパティの定義されているクラス
				new PropertyMetadata(null)      // メタデータ
			);

		// GetXXXとSetXXXが必要。"XXX"はプロパティ名に相当
		public static Action<bool, string> GetCallback( DependencyObject target )
		{
			return (Action<bool, string>)target.GetValue( CallbackProperty );
		}
		public static void SetCallback( DependencyObject target, Action<bool, string> value )
		{
			target.SetValue( CallbackProperty, value );
		}
	}
}
