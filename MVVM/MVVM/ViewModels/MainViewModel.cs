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
                    this.UpperString = this._inputString.ToUpper();
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
                    this.InputString = String.Empty);
                }
                return this._clearCommand;
            }
        }
    }
}
