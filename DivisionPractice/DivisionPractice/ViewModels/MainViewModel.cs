using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionPractice.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private string _lhs;
        /// <summary>
        /// 割られる数に指定される文字列を取得または設定します。
        /// </summary>
        public string Lhs
        {
            get { return this._lhs; }
            set { SetProperty(ref this._lhs, value); }
        }

        private string _rhs;
        /// <summary>
        /// 割る数に指定される文字列を取得または設定します。
        /// </summary>
        public string Rhs
        {
            get { return this._rhs; }
            set { SetProperty(ref this._rhs, value); }
        }

        private string _result;
        /// <summary>
        /// 計算結果を文字列として取得します。
        /// </summary>
        public string Result
        {
            get { return this._result; }
            set { SetProperty(ref this._result, value); }
        }


    }
}
