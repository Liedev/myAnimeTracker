using GalaSoft.MvvmLight.Command;
using MyAnime_DAL;
using MyAnime_DAL.Data;
using MyAnime_DAL.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using static MyAnime_WPF.Components.Delegates;

namespace MyAnime_WPF.ViewModels
{

    public class AdminSerieViewModel: BaseViewModel, IDisposable
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new MyAnimeEntities());
        public ObservableCollection<Category> AnimeCategories { get; set; }
        public ObservableCollection<MyAnime_DAL.Type> AnimeType { get; set; }
        public MyAnime_DAL.Type SelectedAnimeType { get; set; }
        public ObservableCollection<ContentRating> AnimeRating { get; set; }
        public ContentRating SelectedContentRating { get; set; }
        public ObservableCollection<Writer> AnimeWriter { get; set; }
        public Writer SelectedAnimeWriter { get; set; }
        public Serie Serie { get; set; }
        public string UserName { get; set; }
        public string AnimeName { get; set; }
       
        public string AnimeDescription { get; set; }
        public BitmapImage AnimeImage { get; set; }
        public string AnimeErrors { get; set; }
        public string AnimeAirDate { get; set; }
        public string DeleteIsVisible { get; set; }
        public string BtnName { get; set; }
        public RelayCommand<Category> CategorySelectedCommand { get; set; }
        private List<int> SelectedCategories { get; set; }

        LoadImage loadImage = new LoadImage(LoadImageHandler);
        LoadImageFromByteArray loadImageFromByteArray = new LoadImageFromByteArray(LoadImageFromByteArrayHandler);
        ViewsViewModels adminMainView = new ViewsViewModels(AdminMainPageHandler);
        ViewsViewModels userMainView = new ViewsViewModels(UserMainViewHandler);
        ViewsViewModels addEpisodes = new ViewsViewModels(AddEpisodesHandler);
        ViewsViewModels userSettings = new ViewsViewModels(UserSettingsHandler);
        ViewsViewModels logOut = new ViewsViewModels(LoginHandler);
        public AdminSerieViewModel(int? id) 
        {
            SelectedCategories = new List<int>();
            CategorySelectedCommand = new RelayCommand<Category>(this.AddCategoriesToList);
            AnimeCategories = new ObservableCollection<Category>(unitOfWork.CategoryRepo.Get());
            AnimeType = new ObservableCollection<MyAnime_DAL.Type>(unitOfWork.TypeRepo.Get());
            AnimeRating = new ObservableCollection<ContentRating>(unitOfWork.ContentRatingRepo.Get());
            AnimeWriter = new ObservableCollection<Writer>(unitOfWork.WriterRepo.Get());
            AnimeCategories = new ObservableCollection<Category>(unitOfWork.CategoryRepo.Get());
            UserName = UserInfo.UserName;
            if (id == null)
            {                
                BtnName = "Add Serie";
                DeleteIsVisible = "Hidden";
                Serie = new Serie();                
            }
            else
            {
                BtnName = "Edit Serie";
                DeleteIsVisible = "Visible";
                Serie = unitOfWork.SerieRepo.Get(x => x.SerieId == id, x => x.SerieCategories.Select(y => y.Category)).SingleOrDefault();            
                if (Serie != null)
                {
                    AnimeName = Serie.Name;
                    AnimeAirDate = Serie.AirDate.ToString();
                    SelectedAnimeType = Serie.Type;
                    SelectedContentRating = Serie.ContentRating;
                    SelectedAnimeWriter = Serie.Writer; 
                    AnimeDescription = Serie.Description;                    
                    foreach (var item in Serie.SerieCategories)
                    {
                        SelectedCategories.Add(item.CategoryId);
                    }
                    foreach (var item in AnimeCategories)
                    {
                        if (SelectedCategories.Contains(item.CategoryId))
                        {
                            item.IsChecked = true;
                        }
                    }
                    AnimeImage = loadImageFromByteArray(Serie.Image);
                }                
            }            
        }
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "AnimeImage" && AnimeImage == null)
                {
                    return "Insert Image";
                }
                if (columnName == "AnimeName" && string.IsNullOrEmpty(AnimeName))
                {
                    return "Insert Name";
                }
                if (columnName == "AnimeAirDate" && AnimeAirDate == null)
                {
                    return "Insert Airdate";
                }
                if (columnName == "SelectedAnimeWriter" && SelectedAnimeWriter == null)
                {
                    return "Choose a Writer";
                }
                if (columnName == "SelectedAnimeType" && SelectedAnimeType == null)
                {
                    return "Choose a Type";
                }
                if (columnName == "SelectedContentRating" && SelectedContentRating == null)
                {
                    return "Choose a rating";
                }
                if (columnName == "AnimeDescription" && string.IsNullOrEmpty(AnimeDescription))
                {
                    return "Insert Discription";
                }
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Home": return true;
                case "AddEpisodes": return true;
                case "UserView": return true;
                case "UserSettings": return true;
                case "LogOut": return true;
                case "LoadImage": return true;
                case "Series":
                    if (IsValid())
                    {
                        return true;
                    } return false;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Home": adminMainView(); break;
                case "AddEpisodes": addEpisodes(); break;
                case "UserView": userMainView(); break;
                case "UserSettings": userSettings(); break;
                case "Series": Series(); break;
                case "DeleteSerie": DeleteSerie(); break;
                case "LogOut": logOut(); break;
                case "LoadImage": AnimeImage = loadImage(); break;
            }
        }

        private void DeleteSerie()
        {
            if (Serie.SerieId >= 1)
            {
                unitOfWork.SerieRepo.Delete(Serie.SerieId);
                if (unitOfWork.Save() > 0)
                {
                    Dispose();
                    adminMainView();
                }
                else
                {
                    AnimeErrors += "Delete failed, try again later";
                }
            }
            else
            {
                AnimeErrors += "Can't delete what does not excist!";
            }
        }

        private void AddCategoriesToList(Category category)
        {
            if (category.IsChecked == true)
            {
                SelectedCategories.Add(category.CategoryId);
            }
            else
            {
                SelectedCategories.Remove(category.CategoryId);
            }            
        }
        private void Series()
        {
            ConvertImage convertImage = new ConvertImage(ConvertImageHandler);          
            Serie.Image = convertImage(AnimeImage);
            Serie.Name = AnimeName;
            Serie.AirDate = DateTime.Parse(AnimeAirDate);
            Serie.Description = AnimeDescription;
            Serie.TypeId = SelectedAnimeType.TypeID;
            Serie.ContentRatingId = SelectedContentRating.ContentRatingId;
            Serie.UserId = UserInfo.Id;
            Serie.WriterId = SelectedAnimeWriter.WriterId;
            
            SerieCategory serieCategory;
            List<SerieCategory> serieCategories = new List<SerieCategory>();
   
            if (Serie.IsValid())
            {
                foreach (var item in SelectedCategories)
                {
                    serieCategory = new SerieCategory();
                    serieCategory.CategoryId = item;
                    serieCategory.SerieId = Serie.SerieId;
                    if (serieCategory.IsValid())
                    {
                        serieCategories.Add(serieCategory);
                    }
                }
                if (Serie.SerieId > 0)
                {
                    List<SerieCategory> databaseSerieCategories = Serie.SerieCategories.ToList();
                    // If I don't put this in a local variable an error will be thrown because I change the SerieCategory's Repository 
                    foreach (SerieCategory item in databaseSerieCategories)
                    {
                        if (!serieCategories.Contains(item))
                        {
                            unitOfWork.SerieCategoryRepo.Delete(item);//If the serieCategorie is not selected in the view, delete it from the database;
                        }
                        else
                        {
                            serieCategories.Remove(item);//If the item already excists in the database I remove it from the to add categories
                        }
                    }
                    unitOfWork.SerieRepo.Update(Serie);
                }
                else
                {                                      
                    unitOfWork.SerieRepo.Insert(Serie);
                }
                unitOfWork.SerieCategoryRepo.CreateRange(serieCategories);

            }
            if (unitOfWork.Save() > 0)
            {
                Dispose();
                adminMainView();
            }
        }                                              
        private void LogOut(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
