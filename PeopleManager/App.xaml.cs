using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using PeopleManager.ViewModels;
using PeopleManager.Views;
using Prism.Events;
using System;

namespace PeopleManager
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }
        public App()
        {
            this.InitializeComponent();
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IEventAggregator, EventAggregator>();

            services.AddTransient<HeaderOrganismViewModel>();
            services.AddTransient<PeopleListViewModel>();

            Services = services.BuildServiceProvider();
        }

        public static T GetService<T>() => Services.GetRequiredService<T>();

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window m_window;
    }
}
