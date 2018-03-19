using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ContactApp.Models;
using SL;
using Xamarin.Forms;

namespace ContactApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private Page _currentPage;

        private Action<string, string> _displayInfoAction;

        private bool _isBusy;


        private INavigation _nav;

        private string _title = string.Empty;

        private Random r = new Random();

        public BaseViewModel()
        {
            ContactList.CreateTableAsync21();
        }

        public IDataStore<Contact> ContactList =>
            DependencyInject<IDataStore<Contact>>.Get() ?? new DataStore<Contact>("DataBase.db3");

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }


        public Command LoadItemsCommand { get; set; }

        public INavigation Nav
        {
            get => _nav;
            set => SetProperty(ref _nav, value);
        }

        public Page CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }

        public Action<string, string> DisplayInfoAction
        {
            get => _displayInfoAction;
            set => SetProperty(ref _displayInfoAction, value);
        }

        public void OpenPage()
        {
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
                Nav.PushAsync(CurrentPage);
            }
        }

        public void OpenModalPage()
        {
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
                Nav.PushModalAsync(CurrentPage);
            }
        }

        public async Task ExecuteLoadItemsCommand(ObservableCollection<Contact> lst)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                lst.Clear();
                var items = await ContactList.GetAllAsync();
                foreach (var item in items) lst.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}