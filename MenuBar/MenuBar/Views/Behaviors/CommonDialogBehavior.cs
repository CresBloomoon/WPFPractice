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
                                                new PropertyMetadata(null));

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
    }
}
