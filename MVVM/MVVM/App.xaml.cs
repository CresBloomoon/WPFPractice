using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM
{
    using System.Windows;
    using MVVM.ViewModels;
    using MVVM.Views;
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var w = new MainWIndow();
            var vm = new MainViewModel();
            w.DataContext = vm;
            w.Show();
        }
    }
}
