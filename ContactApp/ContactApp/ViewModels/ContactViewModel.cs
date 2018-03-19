using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
        private ICommand _addContact;

        private ICommand _itemTapped;
        private ObservableCollection<Contact> _listContact;

        public ContactViewModel()
        {
            ItemTapped = new Command<object>(Handle_ItemTapped);
            AddContact = new Command(Handle_AddContact);
            ListContact = new ObservableCollection<Contact>();
            //Task.Run(async () => await ExecuteLoadItemsCommand(ListContact));
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(ListContact));
            Nav = new NavigationProxy();
            CurrentPage = new ContactPage();
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new ContactPage();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<AddContactViewModel, Contact>(this, "AddItem", async (obj, item) =>
            {
                var _item = item;
                ListContact.Add(_item);
                await ContactList.AddAsync(_item);
            });

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditItem", async (obj, item) =>
            {
                var _item = item;
                var _Contact = ListContact.FirstOrDefault(arg => arg.Id == _item.Id);
                var idct = ListContact.IndexOf(_Contact);
                ListContact.Remove(_Contact);
                ListContact.Add(_item);
                //ListContact.Insert(idct, _item);
                await ContactList.UpdateAsync(_item);
            });

            MessagingCenter.Subscribe<ContactDetailViewModel, Contact>(this, "DeleteItem", async (obj, item) =>
            {
                var _item = item;
                ListContact.Remove(_item);
                await ContactList.DeleteAsync(_item);
            });
        }


        public ContactViewModel(INavigation navi)
        {
            ItemTapped = new Command<object>(Handle_ItemTapped);
            AddContact = new Command(Handle_AddContact);
            ListContact = new ObservableCollection<Contact>();
            //Task.Run(async () => await ExecuteLoadItemsCommand(ListContact));
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(ListContact));
            Nav = navi;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new ContactPage();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<AddContactViewModel, Contact>(this, "AddItem", async (obj, item) =>
            {
                var _item = item;
                ListContact.Add(_item);
                await ContactList.AddAsync(_item);
            });

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditItem", async (obj, item) =>
            {
                var _item = item;
                var _Contact = ListContact.FirstOrDefault(arg => arg.Id == _item.Id);
                var idct = ListContact.IndexOf(_Contact);
                ListContact.Remove(_Contact);
                ListContact.Add(_item);
                //ListContact.Insert(idct, _item);
                await ContactList.UpdateAsync(_item);
            });

            MessagingCenter.Subscribe<ContactDetailViewModel, Contact>(this, "DeleteItem", async (obj, item) =>
            {
                var _item = item;
                ListContact.Remove(_item);
                await ContactList.DeleteAsync(_item);
            });
        }

        public ContactViewModel(INavigation navi, ContentPage page1)
        {
            ItemTapped = new Command<object>(Handle_ItemTapped);
            AddContact = new Command(Handle_AddContact);
            ListContact = new ObservableCollection<Contact>();
            //Task.Run(async () => await ExecuteLoadItemsCommand(ListContact));
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(ListContact));
            Nav = navi;
            CurrentPage = page1;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new ContactPage();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<AddContactViewModel, Contact>(this, "AddItem", async (obj, item) =>
            {
                var _item = item;
                ListContact.Add(_item);
                await ContactList.AddAsync(_item);
            });

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditItem", async (obj, item) =>
            {
                var _item = item;
                var _Contact = ListContact.FirstOrDefault(arg => arg.Id == _item.Id);
                var idct = ListContact.IndexOf(_Contact);
                ListContact.Remove(_Contact);
                ListContact.Add(_item);
                //ListContact.Insert(idct, _item);
                await ContactList.UpdateAsync(_item);
            });

            MessagingCenter.Subscribe<ContactDetailViewModel, Contact>(this, "DeleteItem", async (obj, item) =>
            {
                var _item = item;
                ListContact.Remove(_item);
                await ContactList.DeleteAsync(_item);
            });
        }

        public ContactViewModel(ContentPage page1)
        {
            ItemTapped = new Command<object>(Handle_ItemTapped);
            AddContact = new Command(Handle_AddContact);
            ListContact = new ObservableCollection<Contact>();
            //Task.Run(async () => await ExecuteLoadItemsCommand(ListContact));
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand(ListContact));
            CurrentPage = page1;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new ContactPage();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<AddContactViewModel, Contact>(this, "AddItem", async (obj, item) =>
            {
                var _item = item;
                ListContact.Add(_item);
                await ContactList.AddAsync(_item);
            });

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditItem", async (obj, item) =>
            {
                var _item = item;
                var _Contact = ListContact.FirstOrDefault(arg => arg.Id == _item.Id);
                var idct = ListContact.IndexOf(_Contact);
                ListContact.Remove(_Contact);
                ListContact.Add(_item);
                //ListContact.Insert(idct, _item);
                await ContactList.UpdateAsync(_item);
            });

            MessagingCenter.Subscribe<ContactDetailViewModel, Contact>(this, "DeleteItem", async (obj, item) =>
            {
                var _item = item;
                ListContact.Remove(_item);
                await ContactList.DeleteAsync(_item);
            });
        }

        public ObservableCollection<Contact> ListContact
        {
            get => _listContact;
            set => SetProperty(ref _listContact, value);
        }

        public ICommand ItemTapped
        {
            get => _itemTapped;
            set => SetProperty(ref _itemTapped, value);
        }

        public ICommand AddContact
        {
            get => _addContact;
            set => SetProperty(ref _addContact, value);
        }


        public void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Contact) e.SelectedItem;
            //ContactDetailViewModel page = null;
            //if (item == null)
            //    return;

            //page = DependencyInject<ContactDetailViewModel>.Get() ?? (ContactDetailViewModel)Activator.CreateInstance(typeof(ContactDetailViewModel));
            //page.Title = item.Name;
            //NavigationPage nextPage = new NavigationPage(page.CurrentPage = new ContactDetail(item));
            //nextPage.BarBackgroundColor = Color.FromHex("#dcb34a");
            //Nav.PushAsync(nextPage);
        }


        private new async Task ExecuteLoadItemsCommand(ObservableCollection<Contact> lst)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                if (lst != null) lst.Clear();

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

        public void Handle_ItemTapped(object o)
        {
            var res = o as Contact;
            var ct = new ContactDetailViewModel(Nav, res);
            ct.Itemnew = res;
            var newpage = new ContactDetail(ct);
            ct.CurrentPage = newpage;
            ct.OpenPage();
            ct.CurrentPage.BindingContext = ct;
            //newpage.DisplayDeletePrompt(res);
        }

        public void Handle_AddContact()
        {
            var addct = new AddContactViewModel(Nav);
            addct.CurrentPage = new AddContact();
            addct.OpenPage();
            addct.CurrentPage.BindingContext = addct;
        }
    }
}