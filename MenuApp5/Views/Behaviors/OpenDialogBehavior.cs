// ---------------------------------------------------------------------
// <copyright file="OpenDialogBehavior.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2019 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System;
using System.Windows;


namespace MenuApp5.Views.Behaviors
{
	internal class OpenDialogBehavior
	{
		/// <summary>
		///  DataContext 添付プロパティ
		/// </summary>
		public static readonly DependencyProperty DataContextProperty =
			DependencyProperty.RegisterAttached(
				"DataContext",
				typeof (object),
				typeof ( OpenDialogBehavior ),
				new PropertyMetadata(null)
			);
		public static object GetDataContext( DependencyObject target )
		{
			return target.GetValue( DataContextProperty );
		}
		public static void SetDataContext( DependencyObject target, object value )
		{
			target.SetValue(DataContextProperty, value);
		}

		/// <summary>
		/// WindowType 添付プロパティ
		/// </summary>
		public static readonly DependencyProperty WindowTypeProperty =
			DependencyProperty.RegisterAttached(
				"WindowType",
				typeof(Type),
				typeof(OpenDialogBehavior),
				new PropertyMetadata(null)
			);
		public static Type GetWindowType(DependencyObject target)
		{
			return (Type)target.GetValue(WindowTypeProperty);
		}
		public static void SetWindowType(DependencyObject target, Type value)
		{
			target.SetValue(WindowTypeProperty, value);
		}
		/// <summary>
		/// Callback 添付プロパティ
		/// </summary>
		public static readonly DependencyProperty CallbackProperty =
			DependencyProperty.RegisterAttached(
				"Callback",
				typeof(Action<bool>),
				typeof(OpenDialogBehavior),
				new PropertyMetadata(null, OnCallbackPropertyChanged)
			);
		public static Action<bool> GetCallback(DependencyObject target)
		{
			return (Action<bool>)target.GetValue(CallbackProperty);
		}
		public static void SetCallback(DependencyObject target, Action<bool> value)
		{
			target.SetValue(CallbackProperty, value);
		}

		private static void OnCallbackPropertyChanged( DependencyObject sender, DependencyPropertyChangedEventArgs args )
		{
			Action<bool> callback = GetCallback( sender );
			if(callback == null ) 
			{
				return;
			}
			Type type = GetWindowType( sender );
			var obj = type.InvokeMember( 
				null,
				System.Reflection.BindingFlags.CreateInstance,
				null,
				null,
				null
			);
			Window child = obj as Window;
			if( child != null ) 
			{
				child.DataContext = GetDataContext( sender );
				bool? result = child.ShowDialog();
				callback.Invoke( (result == null ? false : (bool)result ));
			}
		}
	}
}
