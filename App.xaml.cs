using Boff.KeywordTools.AppServices;
using Boff.KeywordTools.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Boff.KeywordTools
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.StartupUri = new Uri("MainWindow.xaml", uriKind: UriKind.Relative);

            //Config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            Ioc.Default.ConfigureServices(App.ConfigureServices());
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IKeywordService, KeywordService>();
            services.AddTransient<ExtractKeywordPageViewModel>();
 
            return services.BuildServiceProvider();
        }
    }
}
