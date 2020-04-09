// ---------------------------------------------------------------------
// <copyright file="ScrollViewerBehavior.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;

namespace ListApp1.Views.Behaviors
{
	class ScrollViewerBehavior
	{
		/// <summary>
		/// 複数行のテキストを扱う
		/// テキスト追加時に最終行が表示されるようにする
		/// 初期値がfalseなので、ViewでTrueに設定されると最初にIsBodyChangedが呼ばれる。
		/// そのタイミングで、イベントをセットしておくパターンですね。
		/// </summary>
		public static readonly DependencyProperty AutoScrollToEndProperty =
					DependencyProperty.RegisterAttached(
						"AutoScrollToEnd", typeof(bool),
						typeof(ScrollViewerBehavior),
						new UIPropertyMetadata(false, IsBodyChanged)
					);


		public static bool GetAutoScrollToEnd(DependencyObject obj)
		{
			return (bool)obj.GetValue(AutoScrollToEndProperty);
		}

		public static void SetAutoScrollToEnd(DependencyObject obj, bool value)
		{
			obj.SetValue(AutoScrollToEndProperty, value);
		}

		private static void IsBodyChanged
			(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			ScrollViewer viewer = sender as ScrollViewer;
			if (viewer == null )
			{
				return;
			}
		//	viewer.ScrollChanged += OnScrollChanged; // ←このパターンか、下記のラムダ式でも良い。
			viewer.ScrollChanged += ( obj, args ) =>
			{
				ScrollViewer scrollViewer = obj as ScrollViewer;
				if (scrollViewer == null)
				{
					return;
				}
				if (args.ExtentHeightChange > 0.0 && args.ExtentHeight > scrollViewer.ViewportHeight)
				{
					scrollViewer.ScrollToBottom();
				}
			};
		}

		private static void OnScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			ScrollViewer viewer = sender as ScrollViewer;
			if( viewer == null ) 
			{
				return;
			}
			if( e.ExtentHeightChange > 0.0 && e.ExtentHeight > viewer.ViewportHeight ) {
				viewer.ScrollToBottom();
			}
		}
	}
}
