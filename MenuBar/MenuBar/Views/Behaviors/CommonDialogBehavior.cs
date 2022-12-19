using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MenuBar.Views.Behaviors
{
    /// <summary>
    /// コモンダイアログに関するビヘイビアを表します。
    /// </summary>
    internal class CommonDialogBehavior
    {
        #region Callback 添付プロパティ

        /// <summary>
        /// Action型のCallback添付プロパティを定義します。
        /// </summary>
        public static readonly DependencyProperty CallbackProperty =
            DependencyProperty.RegisterAttached("Callback",
                                                typeof(Action<bool, string>),
                                                typeof(CommonDialogBehavior),
                                                new PropertyMetadata(null, OnCallbackPropertyChanged));

        /// <summary>
        /// Callback添付プロパティを取得します。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Action<bool, string> GetCallback(DependencyObject target)
        {
            return (Action<bool, string>)target.GetValue(CallbackProperty);
        }

        /// <summary>
        /// Callback添付プロパティを設定します。  
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetCallback(DependencyObject target, Action<bool, string> value)
        {
            target.SetValue(CallbackProperty, value);
        }

        #endregion Callback 添付プロパティ 

        #region Title 添付プロパティ
        /// <summary>
        /// string型のTitle添付プロパティを定義します。
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.RegisterAttached("Title",
                                                typeof(string),
                                                typeof(CommonDialogBehavior),
                                                new PropertyMetadata("ファイルを開く"));

        /// <summary>
        /// Title添付プロパティを取得します。
        /// </summary>
        /// <param name="target">対象とするDependencyObjectを指定します。</param>
        /// <returns>取得した値を返します。</returns>
        public static string GetTitle(DependencyObject target)
        {
            return (string)target.GetValue(TitleProperty);
        }

        /// <summary>
        /// Title添付プロパティを設定します。
        /// </summary>
        /// <param name="target">対象とするDependencyObjectを指定します。</param>
        /// <param name="value">設定する値を指定します。</param>
        public static void SetTitle(DependencyObject target, string value)
        {
            target.SetValue (TitleProperty, value);
        }
        #endregion Title 添付プロパティ

        #region Filter 添付プロパティ
        /// <summary>
        /// string型のFilter添付プロパティを定義します。
        /// </summary>
        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.RegisterAttached("Filter",
                                                typeof(string),
                                                typeof(CommonDialogBehavior),
                                                new PropertyMetadata("すべてのファイル(*.*)|*.*"));

        /// <summary>
        /// Filter添付プロパティを取得します
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static string GetFilter(DependencyObject target)
        {
            return (string)target.GetValue(FilterProperty);
        }

        /// <summary>
        /// Filter添付プロパティを設定します。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetFilter(DependencyObject target, string value)
        {
            target.SetValue(FilterProperty, value);
        }
        #endregion Filter 添付プロパティ

        #region Multiselect 添付プロパティ
        /// <summary>
        /// bool型のMultiselect添付プロパティを定義します。
        /// </summary>
        public static readonly DependencyProperty MultiselectProperty =
            DependencyProperty.RegisterAttached("Multiselect",
                                                typeof(bool),
                                                typeof(CommonDialogBehavior),
                                                new PropertyMetadata(true));

        /// <summary>
        /// Multiselect添付プロパティを設定します。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool GetMultiselect(DependencyObject target)
        {
            return (bool)target.GetValue(MultiselectProperty);
        }

        public static void SetMultiselect(DependencyObject target, bool value)
        {
            target.SetValue(MultiselectProperty, value);
        }
        #endregion Multiselect 添付プロパティ

        #region アプリケーションを終了する
        private DelegateCommand _exitCommand;

        /// <summary>
        /// アプリケーション終了コマンドを取得します。
        /// </summary>
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
        /// <exception cref="NotImplementedException"></exception>
        private void OnExit()
        {
            App.Current.Shutdown();
        }
        #endregion アプリケーションを終了する









        /// <summary>
        /// Callback添付プロパティ変更イベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private static void OnCallbackPropertyChanged(DependencyObject sender,
                                                      DependencyPropertyChangedEventArgs e)
        {
            var callback = GetCallback(sender);
            if (callback != null)
            {
                var dlg = new OpenFileDialog()
                {
                    Title = GetTitle(sender),
                    Filter = GetFilter(sender),
                    Multiselect = GetMultiselect(sender),
                };
                var owner = Window.GetWindow(sender);
                var result = dlg.ShowDialog(owner);
                callback(result.Value, dlg.FileName);
            }
        }
    }
}
