using MyAnime_WPF.ViewModels;
using MyAnime_WPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyAnime_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //https://stackoverflow.com/questions/3439320/is-there-a-way-to-start-a-wpf-application-without-startupuri-that-doesnt-break/3439944
        // Overriden mainwindow start up
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                LogInViewModel logInViewModel = new LogInViewModel();
                LogInView logInView = new LogInView();
                logInView.DataContext = logInViewModel;
                logInView.Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
