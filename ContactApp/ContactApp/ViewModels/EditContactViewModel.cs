using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using ContactApp.Models;
using ContactApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ContactApp.ViewModels
{
    class EditContactViewModel : BaseViewModel
    {
        private Contact _itemnew;

        public Contact Itemnew
        {
            get => _itemnew;
            set => SetProperty(ref _itemnew, value);
        }

        private ICommand _addContact;
        public ICommand SaveContact
        {
            get => _addContact;
            set => SetProperty(ref _addContact, value);
        }
       

     

        public EditContactViewModel(Contact ctparam = null)
        {
            SaveContact = new Command(Handle_AddContact);
            Itemnew = ctparam ?? new Contact
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Item name",
                CellNumber = "Enter Cellnum here ",
                ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
            };

            this.Nav = new NavigationProxy();
            this.CurrentPage = new EditContact();
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                this.CurrentPage = new EditContact();
                CurrentPage.BindingContext = this;
            }
        }


        public EditContactViewModel(INavigation navi, Contact ctparam = null)
        {
            SaveContact = new Command(Handle_AddContact);
            Itemnew = ctparam ?? new Contact
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Item name",
                CellNumber = "Enter Cellnum here ",
                ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
            };

            this.Nav = navi;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                this.CurrentPage = new EditContact();
                CurrentPage.BindingContext = this;
            }
        }

        public EditContactViewModel(INavigation navi, ContentPage page1, Contact ctparam = null)
        {
            SaveContact = new Command(Handle_AddContact);
            Itemnew = ctparam ?? new Contact
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Item name",
                CellNumber = "Enter Cellnum here ",
                ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
            };

            this.Nav = navi;
            this.CurrentPage = page1;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                this.CurrentPage = new EditContact();
                CurrentPage.BindingContext = this;
            }
        }

        public EditContactViewModel(ContentPage page1, Contact ctparam = null)
        {
            SaveContact = new Command(Handle_AddContact);
            Itemnew = ctparam ?? new Contact
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Item name",
                CellNumber = "Enter Cellnum here ",
                ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
            };

            this.CurrentPage = page1;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                this.CurrentPage = new EditContact();
                CurrentPage.BindingContext = this;
            }
        }

        public void Handle_AddContact()
        {
            var _item = Itemnew as Contact;
            MessagingCenter.Send(this, "EditItem", _item);
            MessagingCenter.Send(this, "EditViewItem", _item);
            this.Nav.PopAsync();

        }
    }
}
