using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    internal class DelegateCommand : ICommand
    {
        /// <summary>
        /// コマンド実行時の処理内容を保持します
        /// </summary>
        private Action<object> _execute;

        /// <summary>
        /// コマンド実行可能判別の処理内容を保持します
        /// </summary>
        private Func<object, bool> _canExecute;


        /// <summary>
        /// 新しいインスタンスを生成します
        /// </summary>
        /// <param name="execute"></param>
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {

        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        #region ICommandの実装

        /// <summary>
        /// 実行可能かどうかの判別処理に関する状態が変更されたときに発生します。
        /// </summary>
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return (this._canExecute != null) ? this._canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            if (this._execute != null)
            {
                this._execute(parameter);
            }
        }

        #endregion ICommandの実装
    }
}
