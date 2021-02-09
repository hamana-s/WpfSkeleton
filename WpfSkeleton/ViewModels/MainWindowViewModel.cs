using Microsoft.Extensions.Logging;
using Models;
using Models.DB.Context;
using Models.DB.Tables;
using Models.Services;
using Prism.Mvvm;
using Reactive.Bindings;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace WpfSkeleton.ViewModels
{
    /// <summary>MainWindowのViewModelクラス</summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>DBコンテキスト</summary>
        private readonly DbContextBase dbContext;

        /// <summary>アプリケーション名</summary>
        public ReactivePropertySlim<string> AppName { get; } = new ReactivePropertySlim<string>();

        /// <summary>足し合わせる値の左辺</summary>
        public ReactivePropertySlim<uint> A { get; } = new ReactivePropertySlim<uint>();

        /// <summary>足し合わせる値の右辺</summary>
        public ReactivePropertySlim<uint> B { get; } = new ReactivePropertySlim<uint>();

        /// <summary>結果</summary>
        public ReactivePropertySlim<uint> Result { get; } = new ReactivePropertySlim<uint>();

        /// <summary>計算の実行</summary>
        public ReactiveCommand CalculateCommand { get; }

        /// <summary>追加するサンプルのデータ</summary>
        public ReactivePropertySlim<string> SampleData { get; } = new ReactivePropertySlim<string>();

        /// <summary>サンプルデータの一覧</summary>
        public ReactivePropertySlim<IEnumerable<Sample>> SampleDatas { get; } = new ReactivePropertySlim<IEnumerable<Sample>>();

        /// <summary>サンプル追加コマンド</summary>
        public ReactiveCommand AddSampleCommand { get; }

        /// <summary>コンストラクタ</summary>
        /// <param name="setting">設定(DI)</param>
        /// <param name="cal">計算(DI)</param>
        /// <param name="dbContext">DBコンテキスト</param>
        /// <param name="logger">ログ(DI)</param>
        public MainWindowViewModel(Settings setting, Calculation cal, DbContextBase dbContext, ILogger logger)
        {
            AppName.Value = setting.AppName;
            this.dbContext = dbContext;

            CalculateCommand = new ReactiveCommand();
            CalculateCommand.Subscribe(() =>
            {
                Result.Value = cal.Sum(A.Value, B.Value);
                logger.LogInformation($"A:{A.Value} + B:{B.Value} = {Result.Value}");
            });

            AddSampleCommand = SampleData.Select(x => !x.IsEmpty()).ToReactiveCommand();
            AddSampleCommand.Subscribe(() =>
            {
                dbContext.Samples.Add(new Sample { Data = SampleData.Value });
                dbContext.SaveChanges();
                SampleDatas.Value = dbContext.Samples.ToArray();
                SampleData.Value = null;
            });
            SampleDatas.Value = dbContext.Samples.ToArray();
        }
    }
}