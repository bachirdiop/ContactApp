using System;
using System.Windows.Input;
using ContactApp.Models;
using ContactApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ContactApp.ViewModels
{
    internal class AddContactViewModel : BaseViewModel
    {
        private ICommand _addContact;
        private Contact _itemnew;


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

            Nav = new NavigationProxy();
            CurrentPage = new AddContact();
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new AddContact();
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

            Nav = navi;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new AddContact();
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

            Nav = navi;
            CurrentPage = page1;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new AddContact();
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

            CurrentPage = page1;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new AddContact();
                CurrentPage.BindingContext = this;
            }
        }

        public Contact Itemnew
        {
            get => _itemnew;
            set => SetProperty(ref _itemnew, value);
        }

        public ICommand SaveContact
        {
            get => _addContact;
            set => SetProperty(ref _addContact, value);
        }

        public void Handle_AddContact()
        {
            var _item = Itemnew;
            //Debug.WriteLine(_item.Name+ " - "+Itemnew.Name);
            //ListContact.Add(_item);
            //DataStore.AddContactAsync(_item);
            MessagingCenter.Send(this, "AddItem", Itemnew);
            Nav.PopAsync();
        }
    }
}