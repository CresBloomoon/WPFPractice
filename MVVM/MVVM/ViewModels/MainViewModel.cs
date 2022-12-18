using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string _upperString;

        public string UpperString
        {
            get { return _upperString; }
            private set { SetProperty(ref this._upperString, value); }
        }

        private string _inputString;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var h = this.PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string InputString
        {
            get { return _inputString; }
            set
            {
                if (SetProperty(ref this._inputString, value))
                {
                    this.UpperString = this._inputString.ToUpper();
                    System.Diagnostics.Debug.WriteLine("UpperString=" + this.UpperString);
                }
            }
        }

        /// <summary>
        /// プロパティ値を変更するヘルパ
        /// </summary>
        /// <typeparam name="T">プロパティの型</typeparam>
        /// <param name="target">変更するプロパティの実態をref指定</param>
        /// <param name="value">変更後の値を指定</param>
        /// <param name="propertyName">プロパティ名を指定</param>
        /// <returns>プロパティ値に変更があった場合にtrueを返す</returns>
        private bool SetProperty<T>(ref T target,
                                        T value,
                                        [CallerMemberName] string propertyName = null)
        {
            if (Equals(target, value))
            {
                return false;
            }
            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
