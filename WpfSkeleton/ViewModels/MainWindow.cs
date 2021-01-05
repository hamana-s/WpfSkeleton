using Prism.Mvvm;
using Reactive.Bindings;
using System.Reactive.Linq;
using System.Windows;
using WpfSkeleton.Services;
using WpfSkeleton.Models;

namespace WpfSkeleton.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>アプリケーション名</summary>
        public ReactivePropertySlim<string> AppName { get; set; } = new ReactivePropertySlim<string>();

        /// <summary>入力パス</summary>
        public ReactivePropertySlim<string> InputPath { get; set; } = new ReactivePropertySlim<string>();

        /// <summary>計算実行コマンド</summary>
        public ReactiveCommand Execute { get; set; }

        /// <summary>コンストラクタ</summary>
        /// <param name="setting">設定(DI)</param>
        /// <param name="cal">計算(DI)</param>
        public MainWindowViewModel(Settings setting, Calculation cal)
        {
            AppName.Value = setting.AppName;

            Execute = InputPath.Select(x => !x.IsEmpty()).ToReactiveCommand();
            Execute.Subscribe(() =>
            {
                var ret = cal.Sum(10, 20);
                MessageBox.Show($"{ret}");
            });
        }
    }
}