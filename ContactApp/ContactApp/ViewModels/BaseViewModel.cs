using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ContactApp.Models;
using ContactApp.Services;
using ContactApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ContactApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public IDataStore<Contact> DataStore => DependencyService.Get<IDataStore<Contact>>() ?? new ContactService();
        Random r = new Random();

        bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        string _title = string.Empty;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        
        
        public Command LoadItemsCommand { get; set; }
        
        
        private INavigation _nav;

        public INavigation Nav
        {
            get => _nav;
            set => SetProperty(ref _nav, value);
        }

        private Page _currentPage;
        public Page CurrentPage { get => _currentPage; set => SetProperty(ref _currentPage, value); }

        private Action<string, string> _displayInfoAction;
        public Action<string, string> DisplayInfoAction { get => _displayInfoAction; set => SetProperty(ref _displayInfoAction, value); }

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
                var items = await DataStore.GetContactListAsync(true);
                foreach (var item in items)
                {
                    lst.Add(item);
                }
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
            [CallerMemberName]string propertyName = "",
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
