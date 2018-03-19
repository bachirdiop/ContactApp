using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactApp.Models;
using ContactApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ContactApp.ViewModels
{
    public class ContactDetailViewModel : BaseViewModel
    {
        private ICommand _editContact;
        public ICommand EditContact
        {
            get => _editContact;
            set => SetProperty(ref _editContact, value);
        }

        private ICommand _deleteContact;
        public ICommand DeleteContact
        {
            get => _deleteContact;
            set => SetProperty(ref _deleteContact, value);
        }

        private Contact _itemnew;

        public Contact Itemnew
        {
            get => _itemnew;
            set => SetProperty(ref _itemnew, value);
        }

        public Action<Contact> DisplayDeletePrompt; //pour afficher boite de dialogue

        public ContactDetailViewModel(Contact ctparam = null)
        {
            EditContact = new Command<Object>(Handle_EditContact);
            DeleteContact = new Command<Object>(Handle_DeleteContact);
            Itemnew = ctparam ?? new Contact
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Item name",
                CellNumber = "Enter Cellnum here ",
                ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
            };
            this.Nav = new NavigationProxy();
            this.CurrentPage = new ContactDetail();
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                this.CurrentPage = new ContactDetail();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditViewItem", (obj, item) =>
            {
                var _item = item as Contact;
                Itemnew = _item;
                Itemnew.Name = _item.Name;
                Itemnew.CellNumber = _item.CellNumber;
                CurrentPage.BindingContext = this;
            });
        }


        public ContactDetailViewModel(INavigation navi, Contact ctparam = null)
        {
            EditContact = new Command<Object>(Handle_EditContact);
            DeleteContact = new Command<Object>(Handle_DeleteContact);
            this.Nav = navi;
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
                this.CurrentPage = new ContactDetail();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditViewItem", (obj, item) =>
            {
                var _item = item as Contact;
                Itemnew = _item;
                Itemnew.Name = _item.Name;
                Itemnew.CellNumber = _item.CellNumber;
                CurrentPage.BindingContext = this;
            });
        }

        public ContactDetailViewModel(INavigation navi, ContentPage page1, Contact ctparam = null)
        {
            EditContact = new Command<Object>(Handle_EditContact);
            DeleteContact = new Command<Object>(Handle_DeleteContact);
            this.Nav = navi;
            this.CurrentPage = page1;
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
                this.CurrentPage = new ContactDetail();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditViewItem", (obj, item) =>
            {
                var _item = item as Contact;
                Itemnew = _item;
                Itemnew.Name = _item.Name;
                Itemnew.CellNumber = _item.CellNumber;
                CurrentPage.BindingContext = this;
            });
        }

        public ContactDetailViewModel(ContentPage page1, Contact ctparam = null)
        {
            EditContact = new Command<Object>(Handle_EditContact);
            DeleteContact = new Command<Object>(Handle_DeleteContact);
            this.CurrentPage = page1;
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
                this.CurrentPage = new ContactDetail();
                CurrentPage.BindingContext = this;
            }

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditViewItem",  (obj, item) =>
            {
                var _item = item as Contact;
                Itemnew = _item;
                Itemnew.Name = _item.Name;
                Itemnew.CellNumber = _item.CellNumber;
                CurrentPage.BindingContext = this;
            });
        }

        public void Handle_EditContact(Object o)
        {
            Contact res = o as Contact;
            EditContactViewModel edct = new EditContactViewModel(this.Nav,res);
            edct.CurrentPage = new EditContact();
            edct.OpenPage();
            edct.CurrentPage.BindingContext = edct;

        }

        public void Handle_DeleteContact(Object o)
        {
            Contact res = o as Contact;
            ContactDetail currpage = CurrentPage as ContactDetail;
            DisplayDeletePrompt = currpage.DisplayDeletePrompt;
            DisplayDeletePrompt(res);

        }

    }
}
