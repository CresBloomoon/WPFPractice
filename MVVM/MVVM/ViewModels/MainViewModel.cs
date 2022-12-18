using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    internal class MainViewModel : NotificationObject
    {
        private string _upperString;

        public string UpperString
        {
            get { return this._upperString; }
            private set { SetProperty(ref this._upperString, value); }
        }

        private string _inputString;
        public string InputString
        {
            get { return this._inputString; }
            set
            {
                if (SetProperty(ref this._inputString, value))
                {
                    //入力された文字列を大文字に変換します
                    this.UpperString = this._inputString.ToUpper();
                    //コマンドの実行可能判別結果に影響を与えているので変更通知を行います
                    this.ClearCommand.RaiseCanExecuteChanged();
                    System.Diagnostics.Debug.WriteLine("Upperstring=" + this.UpperString);
                }
            }
        }

        private DelegateCommand _clearCommand;
        /// <summary>
        /// クリアコマンドを取得します
        /// </summary>
        public DelegateCommand ClearCommand
        {
            get
            {
                if (this._clearCommand == null)
                {
                    this._clearCommand = new DelegateCommand(_ =>
                    {
                        this.InputString = string.Empty;
                    },
                    _ => !string.IsNullOrEmpty(this.UpperString));
                }
                return this._clearCommand;
            }
        }
    }
}
