using MyAnime_WPF.ViewModels;
using MyAnime_WPF.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace MyAnime_WPF.Components
{
    public static class Delegates
    {
        #region delegates
        public delegate BitmapImage LoadImage();

        public delegate BitmapImage LoadImageFromByteArray(Byte[] imageBytes);

        public delegate byte[] ConvertImage(BitmapImage image);

        public delegate void ViewsViewModels();

        public delegate void ViewsViewModelsWithId(int? id);
        #endregion
        #region ImageHandlers
        public static BitmapImage LoadImageHandler()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Select A File";
            openFile.InitialDirectory = "C:\\";
            openFile.Filter = "Image files (*.gif,*.jpg,*.jpeg,*.bmp,*.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.png";
            openFile.Multiselect = false;
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                return new BitmapImage(new Uri(openFile.FileName));

            }
            //https://unsplash.com/photos/St2zVK-Q_mU?utm_source=unsplash&utm_medium=referral&utm_content=creditShareLink
            return new BitmapImage(new Uri(Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), "..", "..", "Images", "karma-talukdar.jpg")));
        }
       
        public static byte[] ConvertImageHandler(BitmapImage animeImage)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(animeImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                return ms.ToArray();
            }
        }

        
        //https://www.codeproject.com/Questions/1022009/Creating-BitmapImage-from-array-of-bytes
        public static BitmapImage LoadImageFromByteArrayHandler(Byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.StreamSource = ms;
                img.EndInit();

                if (img.CanFreeze)
                {
                    img.Freeze();
                }
                return img;
            }
        }
        #endregion

        #region viewNavigationHandlers
        public static void AdminMainPageHandler()
        {            
            AdminMainPageViewModel adminMainPageViewModel = new AdminMainPageViewModel();
            AdminMainPageView adminMainPageView = new AdminMainPageView();
            adminMainPageView.DataContext = adminMainPageViewModel;
            adminMainPageView.Show();
            System.Windows.Application.Current.Windows[0].Close();
        }
        public static void UserSettingsHandler()
        {
            UserSettingsView userSettingsView = new UserSettingsView();
            userSettingsView.Show();
            System.Windows.Application.Current.Windows[0].Close();
        }

        public static void UserMainViewHandler()
        {
            UserMainView userMainView = new UserMainView();
            userMainView.Show();
            System.Windows.Application.Current.Windows[0].Close();
        }

        public static void AddEpisodesHandler()
        {
            AdminAddEpisodesView addEpisodesView = new AdminAddEpisodesView();
            AdminAddEpisodeViewModel adminAddEpisodeViewModel = new AdminAddEpisodeViewModel();
            addEpisodesView.DataContext = adminAddEpisodeViewModel;
            addEpisodesView.Show();
            System.Windows.Application.Current.Windows[0].Close();
        }

        public static void AddOrEditSeriesHandler(int? id)
        {
            AdminSerieViewModel adminAddSerieViewModel = new AdminSerieViewModel(id);
            AdminAddSerieView adminAddSerieView = new AdminAddSerieView();
            adminAddSerieView.DataContext = adminAddSerieViewModel;
            adminAddSerieView.Show();
            System.Windows.Application.Current.Windows[0].Close();
        }

        public static void LoginHandler()
        {
            LogInViewModel logInViewModel = new LogInViewModel();
            LogInView logInView = new LogInView();
            logInView.DataContext = logInViewModel;
            logInView.Show();
            System.Windows.Application.Current.Windows[0].Close();
        }
        #endregion
    }
}
