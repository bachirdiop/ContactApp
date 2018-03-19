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
    class AddContactViewModel : BaseViewModel
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
       

     

        public AddContactViewModel()
        {
            SaveContact = new Command(Handle_AddContact);
            Itemnew = new Contact
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Item name",
                CellNumber = "Enter Cellnum here ",
                ImgSource = ImageSource.FromResource("ContactApp.Images.profile.png")
            };

            this.Nav = new NavigationProxy();
            this.CurrentPage = new AddContact();
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                this.CurrentPage = new AddContact();
                CurrentPage.BindingContext = this;
            }
        }


        public AddContactViewModel(INavigation navi)
        {
            SaveContact = new Command(Handle_AddContact);
            Itemnew = new Contact
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
                this.CurrentPage = new AddContact();
                CurrentPage.BindingContext = this;
            }
        }

        public AddContactViewModel(INavigation navi, ContentPage page1)
        {
            SaveContact = new Command(Handle_AddContact);
            Itemnew = new Contact
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
                this.CurrentPage = new AddContact();
                CurrentPage.BindingContext = this;
            }
        }

        public AddContactViewModel(ContentPage page1)
        {
            SaveContact = new Command(Handle_AddContact);
            Itemnew = new Contact
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
                this.CurrentPage = new AddContact();
                CurrentPage.BindingContext = this;
            }
        }

        public void Handle_AddContact()
        {
            var _item = Itemnew as Contact;
            //Debug.WriteLine(_item.Name+ " - "+Itemnew.Name);
            //ListContact.Add(_item);
            //DataStore.AddContactAsync(_item);
            MessagingCenter.Send(this, "AddItem", Itemnew);
            this.Nav.PopAsync();

        }
    }
}
