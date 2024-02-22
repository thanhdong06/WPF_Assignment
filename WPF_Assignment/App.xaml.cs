using Microsoft.Extensions.DependencyInjection;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Assignment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureService(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureService(ServiceCollection services)
        {
            services.AddSingleton(typeof(IAccountRepo), typeof(AccountRepo));
            services.AddSingleton<MainWindow>();
            services.AddSingleton(typeof(ILoginService), typeof(LoginService));
            services.AddSingleton<Login>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAccountRepo, AccountRepo>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var loginWindow = serviceProvider.GetService<Login>();
            loginWindow.Show();
        }
    }
}
