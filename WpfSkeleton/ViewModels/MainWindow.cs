using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSkeleton
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>アプリケーション名</summary>
        public ReactivePropertySlim<string> AppName { get; set; } = new ReactivePropertySlim<string>();

        /// <summary>コンストラクタ</summary>
        /// <param name="setting">設定(DI)</param>
        /// <param name="cal">計算(DI)</param>
        public MainWindowViewModel(Settings setting, Calculation cal)
        {
            AppName.Value = setting.AppName;

            var ret = cal.Sum(10, 20);
            Console.WriteLine(ret);
        }
    }
}
