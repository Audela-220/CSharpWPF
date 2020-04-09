// ---------------------------------------------------------------------
// <copyright file="DelegateCommand.cs" company="DMG MORI B.U.G. CO.,LTD.">
// Copyright (C) 2020 DMG MORI B.U.G. CO.,LTD. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------
using System;
using System.Windows.Input;

namespace MVVMLib.ViewModels
{
	public class DelegateCommand : ICommand
	{
		/// <summary>
		/// コマンド実行時の処理内容を保持
		/// </summary>
		private Action<object> _execute;

		/// <summary>
		/// コマンド実行可能判定処理内容を保持
		/// 空の場合は実行可能とみなす。
		/// </summary>
		private Func<object, bool> _canExecute;

		/// <summary>
		/// コンストラクタ―
		/// </summary>
		/// <param name="execute"></param>
		public DelegateCommand(Action<object> execute) : this(execute, null) { }
		public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
		{
			this._execute = execute;
			this._canExecute = canExecute;
		}

		/// <summary>
		/// コマンドが実行可能かどうかの判別処理実行
		/// コンストラクターでcanExecuteが指定されない場合（nullの場合）はtrueを返す
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns>実行可能な場合にtrue</returns>
		public bool CanExecute(object parameter)
		{
			return (this._canExecute != null ? this._canExecute(parameter) : true);
		}

		/// <summary>
		/// 実行可能かどうかの判別処理に関する状態が変化した場合に発生するイベント
		/// </summary>
		public event EventHandler CanExecuteChanged;

		/// <summary>
		/// CanExecuteChangedイベントを発行します。
		/// </summary>
		public void RaiseCanExecuteChanged()
		{
			EventHandler handler = this.CanExecuteChanged;
			if (handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// コマンドが実行された時の処理の中身
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter)
		{
			if (this._execute != null)
			{
				this._execute(parameter);
			}
		}
	}
}

