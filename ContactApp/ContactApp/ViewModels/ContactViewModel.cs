using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactApp.Models;
using ContactApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ContactApp.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        private ObservableCollection<Contact> _listContact;

        public ObservableCollection<Contact> ListContact { get => _listContact;
            set => SetProperty(ref _listContact, value);
        }

        private ICommand _itemTapped;
        public ICommand ItemTapped
        {
            get => _itemTapped;
            set => SetProperty(ref _itemTapped, value);
        }

        private ICommand _addContact;
        public ICommand AddContact
        {
            get => _addContact;
            set => SetProperty(ref _addContact, value);
        }

        public ContactViewModel()
        {
            ItemTapped = new Command<Object>(Handle_ItemTapped);
            AddContact = new Command(Handle_AddContact);
            ListContact = new ObservableCollection<Contact>();
            //Task.Run(async () => await ExecuteLoadItemsCommand(ListContact));
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(ListContact));
            this.Nav = new NavigationProxy();
            this.CurrentPage = new ContactPage();
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                this.CurrentPage = new ContactPage();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<AddContactViewModel, Contact>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Contact;
                ListContact.Add(_item);
                await DataStore.AddContactAsync(_item);
            });

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditItem", async (obj, item) =>
            {
                var _item = item as Contact;
                var _Contact = ListContact.FirstOrDefault(arg => arg.Id == _item.Id);
                int idct = ListContact.IndexOf(_Contact);
                ListContact.Remove(_Contact);
                //ListContact.Add(_item);
                ListContact.Insert(idct,_item);
                await DataStore.UpdateContactAsync(_item);
            });

            MessagingCenter.Subscribe<ContactDetailViewModel, Contact>(this, "DeleteItem", async (obj, item) =>
            {
                var _item = item as Contact;
                ListContact.Remove(_item);
                await DataStore.DeleteContactAsync(_item);
            });

        }


        public ContactViewModel(INavigation navi)
        {
            ItemTapped = new Command<Object>(Handle_ItemTapped);
            AddContact = new Command(Handle_AddContact);
            ListContact = new ObservableCollection<Contact>();
            //Task.Run(async () => await ExecuteLoadItemsCommand(ListContact));
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(ListContact));
            this.Nav = navi;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                this.CurrentPage = new ContactPage();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<AddContactViewModel, Contact>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Contact;
                ListContact.Add(_item);
                await DataStore.AddContactAsync(_item);
            });

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditItem", async (obj, item) =>
            {
                var _item = item as Contact;
                var _Contact = ListContact.FirstOrDefault(arg => arg.Id == _item.Id);
                int idct = ListContact.IndexOf(_Contact);
                ListContact.Remove(_Contact);
                //ListContact.Add(_item);
                ListContact.Insert(idct, _item);
                await DataStore.UpdateContactAsync(_item);
            });

            MessagingCenter.Subscribe<ContactDetailViewModel, Contact>(this, "DeleteItem", async (obj, item) =>
            {
                var _item = item as Contact;
                ListContact.Remove(_item);
                await DataStore.DeleteContactAsync(_item);
            });

        }

        public ContactViewModel(INavigation navi,ContentPage page1)
        {
            ItemTapped = new Command<Object>(Handle_ItemTapped);
            AddContact = new Command(Handle_AddContact);
            ListContact = new ObservableCollection<Contact>();
            //Task.Run(async () => await ExecuteLoadItemsCommand(ListContact));
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(ListContact));
            this.Nav = navi;
            this.CurrentPage = page1;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                this.CurrentPage = new ContactPage();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<AddContactViewModel, Contact>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Contact;
                ListContact.Add(_item);
                await DataStore.AddContactAsync(_item);
            });

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditItem", async (obj, item) =>
            {
                var _item = item as Contact;
                var _Contact = ListContact.FirstOrDefault(arg => arg.Id == _item.Id);
                int idct = ListContact.IndexOf(_Contact);
                ListContact.Remove(_Contact);
                //ListContact.Add(_item);
                ListContact.Insert(idct, _item);
                await DataStore.UpdateContactAsync(_item);
            });

            MessagingCenter.Subscribe<ContactDetailViewModel, Contact>(this, "DeleteItem", async (obj, item) =>
            {
                var _item = item as Contact;
                ListContact.Remove(_item);
                await DataStore.DeleteContactAsync(_item);
            });

        }

        public ContactViewModel(ContentPage page1)
        {
            ItemTapped = new Command<Object>(Handle_ItemTapped);
            AddContact = new Command(Handle_AddContact);
            ListContact = new ObservableCollection<Contact>();
            //Task.Run(async () => await ExecuteLoadItemsCommand(ListContact));
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(ListContact));
            this.CurrentPage = page1;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                this.CurrentPage = new ContactPage();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<AddContactViewModel, Contact>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Contact;
                ListContact.Add(_item);
                await DataStore.AddContactAsync(_item);
            });

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditItem", async (obj, item) =>
            {
                var _item = item as Contact;
                var _Contact = ListContact.FirstOrDefault(arg => arg.Id == _item.Id);
                int idct = ListContact.IndexOf(_Contact);
                ListContact.Remove(_Contact);
                
                ListContact.Add(_item);
                //ListContact.Insert(idct, _item);
                await DataStore.UpdateContactAsync(_item);
            });

            MessagingCenter.Subscribe<ContactDetailViewModel, Contact>(this, "DeleteItem", async (obj, item) =>
            {
                var _item = item as Contact;
                ListContact.Remove(_item);
                await DataStore.DeleteContactAsync(_item);
            });
        }


        public void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Contact item = (Contact)e.SelectedItem;
            //ContactDetailViewModel page = null;
            //if (item == null)
            //    return;

            //page = DependencyInject<ContactDetailViewModel>.Get() ?? (ContactDetailViewModel)Activator.CreateInstance(typeof(ContactDetailViewModel));
            //page.Title = item.Name;
            //NavigationPage nextPage = new NavigationPage(page.CurrentPage = new ContactDetail(item));
            //nextPage.BarBackgroundColor = Color.FromHex("#dcb34a");
            //Nav.PushAsync(nextPage);
        }

        

        new async Task ExecuteLoadItemsCommand(ObservableCollection<Contact> lst)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                if (lst != null)
                {
                    lst.Clear();
                }
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

        public void Handle_ItemTapped(Object o)
        {
            Contact res = o as Contact;
            ContactDetailViewModel ct = new ContactDetailViewModel(this.Nav,res);
            ct.Itemnew = res;
            ContactDetail newpage = new ContactDetail(ct);
            ct.CurrentPage = newpage;
            ct.OpenPage();
            ct.CurrentPage.BindingContext = ct;
            //newpage.DisplayDeletePrompt(res);

        }

        public void Handle_AddContact()
        {

           AddContactViewModel addct = new AddContactViewModel(this.Nav);
           addct.CurrentPage = new AddContact();
           addct.OpenPage();
           addct.CurrentPage.BindingContext = addct;

        }

    }
}
