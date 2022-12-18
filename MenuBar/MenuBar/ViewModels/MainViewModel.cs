﻿using System;
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
                        System.Diagnostics.Debug.WriteLine("ファイルを開きます。");
                    }));
            }
        }
    }
}
