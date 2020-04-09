// ---------------------------------------------------------------------
// <copyright file="CloseWindowAttachedBehavior.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
using System.Windows;

namespace MenuApp5.Views.Behaviors
{
	class CloseWindowAttachedBehavior
	{
		// Using a DependencyProperty as the backing store for Close.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CloseProperty =
			DependencyProperty.RegisterAttached(
				"Close", 
				typeof(bool), 
				typeof(CloseWindowAttachedBehavior), 
				new PropertyMetadata(false, OnCloseChanged));

		public static void SetClose(DependencyObject obj, bool value)
		{
			obj.SetValue(CloseProperty, value);
		}
		public static bool GetClose(DependencyObject obj)
		{
			return (bool)obj.GetValue(CloseProperty);
		}

		private static void OnCloseChanged(DependencyObject target, DependencyPropertyChangedEventArgs arg)
		{
			var win = target as Window;
			if (win == null)
			{
				// Window以外のコントロールにこの添付ビヘイビアが付けられていた場合は、
				// コントロールの属しているWindowを取得
				win = Window.GetWindow(target);
			}

			if (GetClose(target)) 
			{
				win.Close();
			}
		}
	}
}
