using System;
using System.Windows.Input;
using ContactApp.Models;
using ContactApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ContactApp.ViewModels
{
    public class ContactDetailViewModel : BaseViewModel
    {
        private ICommand _deleteContact;
        private ICommand _editContact;

        private Contact _itemnew;

        public Action<Contact> DisplayDeletePrompt; //pour afficher boite de dialogue

        public ContactDetailViewModel(Contact ctparam = null)
        {
            EditContact = new Command<object>(Handle_EditContact);
            DeleteContact = new Command<object>(Handle_DeleteContact);
            Itemnew = ctparam ?? new Contact
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Item name",
                CellNumber = "Enter Cellnum here ",
                ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
            };
            Nav = new NavigationProxy();
            CurrentPage = new ContactDetail();
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new ContactDetail();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditViewItem", (obj, item) =>
            {
                var _item = item;
                Itemnew = _item;
                Itemnew.Name = _item.Name;
                Itemnew.CellNumber = _item.CellNumber;
                CurrentPage.BindingContext = this;
            });
        }


        public ContactDetailViewModel(INavigation navi, Contact ctparam = null)
        {
            EditContact = new Command<object>(Handle_EditContact);
            DeleteContact = new Command<object>(Handle_DeleteContact);
            Nav = navi;
            Itemnew = ctparam ?? new Contact
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Item name",
                CellNumber = "Enter Cellnum here ",
                ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
            };
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new ContactDetail();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditViewItem", (obj, item) =>
            {
                var _item = item;
                Itemnew = _item;
                Itemnew.Name = _item.Name;
                Itemnew.CellNumber = _item.CellNumber;
                CurrentPage.BindingContext = this;
            });
        }

        public ContactDetailViewModel(INavigation navi, ContentPage page1, Contact ctparam = null)
        {
            EditContact = new Command<object>(Handle_EditContact);
            DeleteContact = new Command<object>(Handle_DeleteContact);
            Nav = navi;
            CurrentPage = page1;
            Itemnew = ctparam ?? new Contact
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Item name",
                CellNumber = "Enter Cellnum here ",
                ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
            };
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new ContactDetail();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditViewItem", (obj, item) =>
            {
                var _item = item;
                Itemnew = _item;
                Itemnew.Name = _item.Name;
                Itemnew.CellNumber = _item.CellNumber;
                CurrentPage.BindingContext = this;
            });
        }

        public ContactDetailViewModel(ContentPage page1, Contact ctparam = null)
        {
            EditContact = new Command<object>(Handle_EditContact);
            DeleteContact = new Command<object>(Handle_DeleteContact);
            CurrentPage = page1;
            Itemnew = ctparam ?? new Contact
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Item name",
                CellNumber = "Enter Cellnum here ",
                ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
            };
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new ContactDetail();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditViewItem", (obj, item) =>
            {
                var _item = item;
                Itemnew = _item;
                Itemnew.Name = _item.Name;
                Itemnew.CellNumber = _item.CellNumber;
                CurrentPage.BindingContext = this;
            });
        }

        public ICommand EditContact
        {
            get => _editContact;
            set => SetProperty(ref _editContact, value);
        }

        public ICommand DeleteContact
        {
            get => _deleteContact;
            set => SetProperty(ref _deleteContact, value);
        }

        public Contact Itemnew
        {
            get => _itemnew;
            set => SetProperty(ref _itemnew, value);
        }

        public void Handle_EditContact(object o)
        {
            var res = o as Contact;
            var edct = new EditContactViewModel(Nav, res);
            edct.CurrentPage = new EditContact();
            edct.OpenPage();
            edct.CurrentPage.BindingContext = edct;
        }

        public void Handle_DeleteContact(object o)
        {
            var res = o as Contact;
            var currpage = CurrentPage as ContactDetail;
            DisplayDeletePrompt = currpage.DisplayDeletePrompt;
            DisplayDeletePrompt(res);
        }
    }
}