using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MenuBar.Views.Behaviors
{
    /// <summary>
    /// ダイアログを開くためのビヘイビアを表します。
    /// </summary>
    internal sealed class OpenDialogBehavior
    {
        #region DataContext 添付プロパティ
        /// <summary>
        /// object型のDataContext添付プロパティを定義します。
        /// </summary>
        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.RegisterAttached("DataContext",
                                                typeof(object),
                                                typeof(OpenDialogBehavior),
                                                new PropertyMetadata(null));

        /// <summary>
        /// DataContext添付プロパティを設定します。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static object GetDataContext(DependencyObject target)
        {
            return target.GetValue(DataContextProperty);
        }

        public static void SetDataContext(DependencyObject target, object value)
        {
            target.SetValue(DataContextProperty, value);
        }
        #endregion DataContext 添付プロパティ

        #region WindowType 添付プロパティ

        /// <summary>
        /// Type型のWindowType添付プロパティを定義します。
        /// </summary>
        public static readonly DependencyProperty WindowTypeProperty =
            DependencyProperty.RegisterAttached("WindowType",
                                                typeof(Type),
                                                typeof(OpenDialogBehavior),
                                                new PropertyMetadata(null));

        /// <summary>
        /// WindowType添付プロパティを取得します。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Type GetWindowType(DependencyObject target)
        {
            return (Type)target.GetValue(WindowTypeProperty);
        }

        /// <summary>
        /// WindowType添付プロパティを設定します。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetWindowType(DependencyObject target, Type value)
        {
            target.SetValue(WindowTypeProperty, value);
        }
        #endregion WindowType 添付プロパティ

        #region Callback 添付プロパティ
        /// <summary>
        /// Action型のCallback添付プロパティを定義します。
        /// </summary>
        public static readonly DependencyProperty CallbackProperty =
            DependencyProperty.RegisterAttached("Callback",
                                                typeof(Action<bool>),
                                                typeof(OpenDialogBehavior),
                                                new PropertyMetadata(null, OnCallbackPropertyChanged));

        /// <summary>
        /// Callback添付プロパティを取得します。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Action<bool> GetCallback(DependencyObject target)
        {
            return (Action<bool>)target.GetValue(CallbackProperty);
        }

        /// <summary>
        /// Callback添付プロパティを設定します。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public static void SetCallback(DependencyObject target, Action<bool> value)
        {
            target.SetValue(CallbackProperty, value);
        }

        private static void OnCallbackPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var callback = GetCallback(sender);
             if (callback != null)
            {
                var type = GetWindowType(sender);
                var obj = type.InvokeMember(null, System.Reflection.BindingFlags.CreateInstance, null, null, null);
                var child = obj as Window;
                if (child != null)
                {
                    child.DataContext = GetDataContext(sender);
                    var result = child.ShowDialog();
                    callback(result.Value);
                }
            }
        }
        #endregion Callback 添付プロパティ
    }
}
