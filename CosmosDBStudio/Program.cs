﻿using System;
using System.Windows.Threading;
using CosmosDBStudio.Services;
using CosmosDBStudio.Services.Implementation;
using CosmosDBStudio.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace CosmosDBStudio
{
    static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var serviceProvider = CreateServiceProvider();
            var app = serviceProvider.GetRequiredService<App>();
            app.Run();
        }

        private static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            return services.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAccountDirectory, AccountDirectory>();
            services.AddSingleton<IClientPool, ClientPool>();
            services.AddSingleton<ICosmosAccountManager, CosmosAccountManager>();
            services.AddSingleton<IContainerContextFactory, ContainerContextFactory>();
            services.AddSingleton<IQueryPersistenceService, QueryPersistenceService>();
            
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            services.AddSingleton<IMessenger, Messenger>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton(sp => new Lazy<Dispatcher>(() => sp.GetRequiredService<App>().Dispatcher));
            services.AddSingleton<IUIDispatcher, UIDispatcher>();
            services.AddSingleton<IClipboardService, ClipboardService>();

            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<App>();
        }
    }
}