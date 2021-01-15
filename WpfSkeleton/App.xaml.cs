using Microsoft.Extensions.Configuration;
using Models.Models;
using Models.Services;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.IO;
using System.Windows;
using WpfSkeleton.Views;

namespace WpfSkeleton
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                // todo 補足されない例外が発生した場合の処理を書く
            };
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile(path: "appsettings.json");
            var configuration = builder.Build();

            var factory = new NLog.Extensions.Logging.NLogLoggerFactory();
            var logger = factory.CreateLogger("");

            containerRegistry
                .RegisterInstance(configuration.Get<Settings>())
                .RegisterInstance(logger)
                .Register<ICalculation>();
        }
    }
}