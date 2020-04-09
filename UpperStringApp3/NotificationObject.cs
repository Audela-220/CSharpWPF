// ---------------------------------------------------------------------
// <copyright file="NotificationObject.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UpperStringApp3
{
	/// <summary>
	/// ViewModel用の親クラス。
	/// ToDo：将来的にはライブラリへ分離の事。今のところnamespaceはUpperStringApp3です。
	/// </summary>
	internal abstract class NotificationObject : INotifyPropertyChanged
	{
		/// <summary>
		/// プロパティに変更があった場合に発生する
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// PropertyChangedイベントを発生させる
		/// </summary>
		/// <param name="propertyName"></param>
		protected void RaisePorpertyChanged( [CallerMemberName] string propertyName = null )
		{
			var handler = this.PropertyChanged;
			if( handler != null )
			{
				handler( this, new PropertyChangedEventArgs(propertyName) );
			}
		}

		/// <summary>
		/// プロパティ値を変更するヘルパー
		/// </summary>
		/// <typeparam name="T">プロパティの型</typeparam>
		/// <param name="target">変更するプロパティの実体をrefで指定</param>
		/// <param name="value">変更後の値を指定</param>
		/// <param name="propertyName">プロパティ名を指定</param>
		/// <returns></returns>
		protected bool SetProperty<T>( ref T target, T value, [CallerMemberName] string propertyName = null )
		{
			if( Equals( target, value ) )
			{
				return false;
			}
			target = value;
			RaisePorpertyChanged( propertyName );
			return true;
		}

	}
}
