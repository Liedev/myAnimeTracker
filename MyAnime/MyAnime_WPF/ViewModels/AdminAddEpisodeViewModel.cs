using MyAnime_DAL;
using MyAnime_DAL.Data;
using MyAnime_DAL.Data.UnitOfWork;
using MyAnime_WPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media.Imaging;
using static MyAnime_WPF.Components.Delegates;

namespace MyAnime_WPF.ViewModels
{
    public class AdminAddEpisodeViewModel : BaseViewModel, IDisposable
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new MyAnimeEntities());
        public ObservableCollection<Serie> Series { get; set; }
        public string SerieName { get; set; }        
        public string SearchError { get; set; }
        public Serie SelectedSerie { get; set; }
        public BitmapImage EpisodeImage { get; set; }
        public string EpisodeName { get; set; }
        public string EpisodeAirDate { get; set; }
        public string EpisodeDescription { get; set; }
        public string BtnName { get; set; }

        ViewsViewModels adminMainView = new ViewsViewModels(AdminMainPageHandler);
        ViewsViewModels userMainView = new ViewsViewModels(UserMainViewHandler);
        ViewsViewModels userSettings = new ViewsViewModels(UserSettingsHandler);
        ViewsViewModels logOut = new ViewsViewModels(LoginHandler);
        ViewsViewModelsWithId addOrEditSeries = new ViewsViewModelsWithId(AddOrEditSeriesHandler);
        LoadImage loadImage = new LoadImage(LoadImageHandler);
        public AdminAddEpisodeViewModel()
        {
            Series = new ObservableCollection<Serie>(unitOfWork.SerieRepo.Get());
            BtnName = "Add Episode";
        }
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "EpisodeName" && string.IsNullOrEmpty(EpisodeName))
                {
                    return "Insert a name.";
                }
                if (columnName == "EpisodeDescription" && string.IsNullOrEmpty(EpisodeDescription))
                {
                    return "Insert a discription.";
                }
                if (columnName == "SelectedSerie" && SelectedSerie == null)
                {
                    return "Select a serie.";
                }
                if (columnName == "EpisodeAirDate" && EpisodeAirDate == null)
                {
                    return "Insert Airdate";
                }
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Home": return true;
                case "AddSerie": return true;
                case "UserView": return true;
                case "UserSettings": return true;
                case "LogOut": return true;
                case "AddEpisode":
                    if (IsValid())
                    {
                        return true;
                    }
                    return false;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Home": adminMainView(); break;
                case "UserView": userMainView(); break;
                case "UserSettings": userSettings(); break;
                case "AddSerie": addOrEditSeries(null); break;
                case "LogOut": logOut(); break;
                case "Search": Search(); break;
                case "FullList": FullList(); break;
                case "LoadImage": EpisodeImage = loadImage(); break;
                case "AddEpisode": AddEpisode(); break;
            }
        }

        private void AddEpisode()
        {
            ConvertImage convertImage = new ConvertImage(ConvertImageHandler);
            Episode episode = new Episode();
            episode.Image = convertImage(EpisodeImage);
            episode.Name = EpisodeName;
            episode.ReleaseDate = DateTime.Parse(EpisodeAirDate);
            episode.Description = EpisodeDescription;
            List<Episode> episodes = new List<Episode>(unitOfWork.EpisodeRepo.Get());
            episode.Number = episodes.Count + 1;
            episode.SerieId = SelectedSerie.SerieId;
            episode.UserId = UserInfo.Id;
            if (episode.IsValid())
            {
                unitOfWork.EpisodeRepo.CreateOrUpdate(episode);
                if (unitOfWork.Save() > 0)
                {
                    Dispose();
                    AdminMainPageView adminMainPageView = new AdminMainPageView();
                    AdminMainPageViewModel adminMainPageViewModel = new AdminMainPageViewModel();
                    adminMainPageView.DataContext = adminMainPageViewModel;
                    adminMainPageView.Show();
                }
            }
           
        }

        private void FullList()
        {
            SearchError = "";
            Series = new ObservableCollection<Serie>(unitOfWork.SerieRepo.Get());
        }

        private void Search()
        {
            SearchError = "";
            if (SerieName != null)
            {
                Series = new ObservableCollection<Serie>(unitOfWork.SerieRepo.Get().Where(x => x.Name.Contains(SerieName)));
                if (Series.Count == 0)
                {
                    SearchError = "Could not find a serie with that name.";
                }
            }
            else
            {
                SearchError = "Fill in the searchfield. We can't find nothing if there's nothing to find";
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
