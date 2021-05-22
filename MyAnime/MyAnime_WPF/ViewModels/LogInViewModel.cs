using MyAnime_DAL;
using MyAnime_DAL.Data;
using MyAnime_DAL.Data.UnitOfWork;
using MyAnime_WPF.Views;
using System;
using System.Linq;

namespace MyAnime_WPF.ViewModels
{
    public class LogInViewModel: BaseViewModel, IDisposable
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new MyAnimeEntities());
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ErrorInfo { get; set; }
        public AppUser User { get; set; }

        public void LogIn() 
        {            
            User = unitOfWork.UserRepo.Get(u => u.UserName == UserName && u.PasswordHash == Password).FirstOrDefault();
            if (User != null)
            {
                UserInfo.Id = User.UserId;
                UserInfo.UserName = User.UserName;
                if (User.IsAdmin)
                {
                    
                    AdminMainPageViewModel adminMainPageViewModel = new AdminMainPageViewModel();
                    AdminMainPageView adminMainPageView = new AdminMainPageView
                    {
                        DataContext = adminMainPageViewModel
                    };
                    adminMainPageView.Show();
                    System.Windows.Application.Current.Windows[0].Close();
                }
                else
                {                    
                    UserMainView userMainView = new UserMainView();
                    userMainView.Show();
                    System.Windows.Application.Current.Windows[0].Close();
                }
            }
            else
            {
                ErrorInfo = "Could not find your data.";
            }
            Reset();
        }

        private void Reset()
        {
            UserName = "";
            Password = "";
        }

        public void Register() 
        {
            RegisterView register = new RegisterView();
            register.Show();
        }
        public override string this[string columnName]
        {
            get
            {
                    if (columnName == "UserName" && UserName == "")
                    {
                        return "UserName must be filled in" + Environment.NewLine;
                    }
                    if (columnName == "Password" && Password == "")
                    {
                        return "Password must be filled in" + Environment.NewLine;
                    }
                    return "";
            }
        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "LogIn":
                    if (!IsValid())
                    {
                        return false;
                    }
                    return true;
                case "Register": return true;
                case "Close": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "LogIn": LogIn(); break;
                case "Register": Register(); break;
                case "Close": System.Windows.Application.Current.Windows[0].Close(); break;
            }
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }

    }
}
