using DivisionPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisionPractice.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private Calculator _calc;
        public MainViewModel()
        {
            this._calc = new Calculator();
        }
        
        private string _lhs;
        /// <summary>
        /// 割られる数に指定される文字列を取得または設定します。
        /// </summary>
        public string Lhs
        {
            get { return this._lhs; }
            set
            {
                if (SetProperty(ref this._lhs, value))
                {
                    //割られる数が変更されると、実行可能判別処理の結果が変わる可能性があるため
                    //RaiseCanExecuteChanged()を読んで通知させる。
                    this.DivCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _rhs;
        /// <summary>
        /// 割る数に指定される文字列を取得または設定します。
        /// </summary>
        public string Rhs
        {
            get { return this._rhs; }
            set
            {
                if (SetProperty(ref this._rhs, value))
                {
                    //割る数が変更されると、実行可能判別処理の結果が変わる可能性があるため
                    //RaiseCanExecuteChanged()を読んで通知させる。
                    this.DivCommand.RaiseCanExecuteChanged();
                }
            }
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

        private DelegateCommand _divCommand;
        /// <summary>
        /// 割り算コマンドを取得します。
        /// </summary>
        public DelegateCommand DivCommand
        {
            get
            {
                return this._divCommand ?? (this._divCommand = new DelegateCommand(
                    _ =>
                    {
                        OnDivision();
                    },
                    _ =>
                    {
                        var dummy = 0.0;
                        
                        //割られる数がdouble型へ変換できなければコントロールをグレーアウトさせる。
                        if (!double.TryParse(this.Lhs, out dummy)) return false;
                        //割る数がdouble型へ変換できなければコントロールをグレーアウトさせる。
                        if (!double.TryParse(this.Rhs, out dummy)) return false;
                        return true;
                    }));
            }
        }

        /// <summary>
        /// 割り算を実行します。
        /// </summary>
        private void OnDivision()
        {
            var lhs = 0.0;
            var rhs = 0.0;
            if (!double.TryParse(this.Lhs, out lhs)) return;
            if (!double.TryParse(this.Rhs, out rhs)) return;
            this._calc.Lhs = lhs;
            this._calc.Rhs = rhs;
            this._calc.ExecuteDiv();
            this.Result = this._calc.Result.ToString();
        }
    }
}
