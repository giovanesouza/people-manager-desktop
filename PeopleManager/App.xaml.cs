using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using PeopleManager.Utils;
using PeopleManager.ViewModels;
using PeopleManager.Views;
using Prism.Events;
using System;

namespace PeopleManager
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }
        public static Window MainWindow { get; private set; }

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
            var savedTheme = ThemeSettings.LoadUserPreferredTheme();
            MainWindow = new MainWindow();

            if (MainWindow.Content is FrameworkElement rootElement)
                rootElement.RequestedTheme = savedTheme == "Dark" ? ElementTheme.Dark : ElementTheme.Light;

            MainWindow.Activate();
        }
    }
}
