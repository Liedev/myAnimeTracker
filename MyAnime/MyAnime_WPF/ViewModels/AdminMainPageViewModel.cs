using GalaSoft.MvvmLight.CommandWpf;
using MyAnime_DAL;
using MyAnime_DAL.Data;
using MyAnime_DAL.Data.UnitOfWork;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using static MyAnime_WPF.Components.Delegates;

namespace MyAnime_WPF.ViewModels
{
    public class AdminMainPageViewModel : BaseViewModel, IDisposable
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new MyAnimeEntities());
        public ObservableCollection<Serie> Series { get; set; }
        public string UserName { get; set; }
        public string SearchOnName { get; set; }
        public string SearchError { get; set; }
        public RelayCommand<Serie> SerieSelectedCommand { get; set; }    
        ViewsViewModels userMainView = new ViewsViewModels(UserMainViewHandler);
        ViewsViewModels addEpisodes = new ViewsViewModels(AddEpisodesHandler);
        ViewsViewModels userSettings = new ViewsViewModels(UserSettingsHandler);
        ViewsViewModels logOut = new ViewsViewModels(LoginHandler);
        ViewsViewModelsWithId addOrEditSeries = new ViewsViewModelsWithId(AddOrEditSeriesHandler);
   
        public AdminMainPageViewModel()
        {
            UserName = UserInfo.UserName;
            Series = new ObservableCollection<Serie>(unitOfWork.SerieRepo.Get(x => x.Writer,x => x.Type,x => x.Episodes,x => x.ContentRating));
            SerieSelectedCommand = new RelayCommand<Serie>(serie => addOrEditSeries(serie.SerieId));
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "AddSeries": return true;
                case "AddEpisodes": return true;
                case "UserView": return true;
                case "UserSettings": return true;
                case "LogOut": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            { 
                case "AddSeries": addOrEditSeries(null); break;
                case "AddEpisodes": addEpisodes(); break;
                case "UserView": userMainView(); break;
                case "UserSettings": userSettings(); break;
                case "LogOut": logOut(); break;
                case "SearchSerie": SearchSerie(); break;
                case "AllSeries": AllSeries(); break;
            }
        }

        private void SearchSerie()
        {
            SearchError = "";
            if (!string.IsNullOrEmpty(SearchOnName))
            {
                Series = new ObservableCollection<Serie>(unitOfWork.SerieRepo.Get().Where(x => x.Name.ToLower().Contains(SearchOnName.ToLower())));
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

        private void AllSeries()
        {
            SearchError = "";
            SearchOnName = "";
            Series = new ObservableCollection<Serie>(unitOfWork.SerieRepo.Get());
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }    
}
