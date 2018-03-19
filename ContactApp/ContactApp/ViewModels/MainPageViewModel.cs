using System;
using System.Windows.Input;
using ContactApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ContactApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        //premier paramètre récuperé de UI
        private string _login;

        //deuxième paramètre récuperé de UI
        private string _password;
        public Action DisplayContactAction;
        public Action<string, string> DisplayLoginPrompt; //pour afficher boite de dialogue

        public MainPageViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
            Nav = new NavigationProxy();
            CurrentPage = new Views.MainPage(this);
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new Views.MainPage(this);
                CurrentPage.BindingContext = this;
            }
        }


        public MainPageViewModel(INavigation navi)
        {
            SubmitCommand = new Command(OnSubmit);
            Nav = navi;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new Views.MainPage(this);
                CurrentPage.BindingContext = this;
            }
        }

        public MainPageViewModel(INavigation navi, ContentPage page1)
        {
            SubmitCommand = new Command(OnSubmit);
            Nav = navi;
            CurrentPage = page1;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new Views.MainPage(this);
                CurrentPage.BindingContext = this;
            }
        }

        public MainPageViewModel(ContentPage page1)
        {
            SubmitCommand = new Command(OnSubmit);
            CurrentPage = page1;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new Views.MainPage(this);
                CurrentPage.BindingContext = this;
            }
        }


        public string Login //paramètre de Binding au niveau du view
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }

        public string Password //paramètre de Binding au niveau du view
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand SubmitCommand { set; get; }


        public bool LoginFunction(string login, string password)
        {
            if (login == "admin")
                if (password == "admin")
                    return true;
                else
                    return false;
            return false;
        }

        public void OnSubmit()
        {
            var verif = LoginService.Login(Login, Password);


            if (verif)
                DisplayContactAction();
            else
                DisplayLoginPrompt("Error", "Incorrect Login");
        }
    }
}