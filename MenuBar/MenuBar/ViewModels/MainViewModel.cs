using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuBar.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private DelegateCommand _openFileCommand;

        /// <summary>
        /// ファイルを開くコマンドを取得します。
        /// </summary>
        public DelegateCommand OpenFileCommand
        {
            get
            {
                return this._openFileCommand ?? (this._openFileCommand = new DelegateCommand(
                    _ =>
                    {
                        this.DialogCallback = OnDialogCallback;
                    }));
            }
        }

        private Action<bool, string> _dialogCallback;

        /// <summary>
        /// ダイアログに対するコールバックを取得します。
        /// </summary>
        public Action<bool, string> DialogCallback
        {
            get { return this._dialogCallback; }
            private set { SetProperty(ref this._dialogCallback, value); }
        }

        private void OnDialogCallback(bool isOK, string filePath)
        {
            this.DialogCallback = null;
            System.Diagnostics.Debug.WriteLine("コールバック処理を行います");
        }

        #region アプリケーションを終了する
        public Func<bool> ClosingCallback
        {
            get { return OnExit; }
        }

        private DelegateCommand _exitCommand;
        public DelegateCommand ExitCommand
        {
            get
            {
                return this._exitCommand ?? (this._exitCommand = new DelegateCommand(
                    _ =>
                    {
                        OnExit();
                    }));
            }
        }

        /// <summary>
        /// アプリケーションを終了します。
        /// </summary>
        /// <returns></returns>
        private bool OnExit()
        {
            if (this._counter < 3)
            {
                this._counter++;
                return false;
            }

            App.Current.Shutdown();
            return true;
        }

        private int _counter;
        #endregion アプリケーションを終了する
    }
}
