using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MenuBar.Views.Behaviors
{
    /// <summary>
    /// Windowを閉じるときのビヘイビアを表します。
    /// </summary>
    internal class WindowClosingBehavior
    {
        #region Callback 添付プロパティ
        /// <summary>
        /// Func型のCallback添付プロパティを定義します。
        /// </summary>
        public static readonly DependencyProperty CallbackProperty =
            DependencyProperty.RegisterAttached("Callback",
                                                typeof(Func<bool>),
                                                typeof(WindowClosingBehavior),
                                                new PropertyMetadata(null, OnIsEnabledPropertyChanged));
        /// <summary>
        /// Callback添付プロパティを取得します。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Func<bool> GetCallback(DependencyObject target)
        {
            return (Func<bool>)target.GetValue(CallbackProperty);
        }
        
        /// <summary>
        /// Callback添付プロパティを設定します。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetCallback(DependencyObject target, Func<bool> value)
        {
            target.SetValue(CallbackProperty, value);
        }

        /// <summary>
        /// Callback添付プロパティ変更イベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発行元</param>
        /// <param name="e">イベント引数</param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnIsEnabledPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var w = sender as Window;
            if (w != null)
            {
                var callback = GetCallback(w);
                if ((callback != null) && (e.OldValue == null))
                {
                    w.Closing += OnClosing;
                }
                else if (callback == null)
                {
                    w.Closing -= OnClosing;
                }
            }
        }

        /// <summary>
        /// Closingイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnClosing(object sender, CancelEventArgs e)
        {
            var callback = GetCallback(sender as DependencyObject);
            if (callback != null)
            {
                //コールバック処理の結果がfalseのときキャンセルする
                e.Cancel = !callback();
            }
        }
        #endregion Callback 添付プロパティ
    }
}
