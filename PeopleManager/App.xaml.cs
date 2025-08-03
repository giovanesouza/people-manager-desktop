using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.Windows.Globalization;
using PeopleManager.Abstracts;
using PeopleManager.Common;
using PeopleManager.Database;
using PeopleManager.Repositories;
using PeopleManager.Services;
using PeopleManager.ViewModels;
using PeopleManager.Views;
using Prism.Events;
using System;
using System.IO;

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
            //ApplicationLanguages.PrimaryLanguageOverride = "en-US";
            ApplicationLanguages.PrimaryLanguageOverride = "pt-BR";
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IEventAggregator, EventAggregator>();
            services.AddSingleton<ILocalizationService, LocalizationService>();

            string connectionString = $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db", "DBSQLite.db")};Version=3;";
            services.AddSingleton(connectionString);

            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IOpenUrlHelperService, OpenUrlHelperService>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<ISortService, SortService>();
            services.AddSingleton<DBConnection>();

            services.AddTransient<HeaderOrganismViewModel>();
            services.AddTransient<PeopleListViewModel>();
            services.AddTransient<PeopleListItemViewModel>();
            services.AddTransient<FooterViewModel>();
            services.AddTransient<PersonService>();

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
