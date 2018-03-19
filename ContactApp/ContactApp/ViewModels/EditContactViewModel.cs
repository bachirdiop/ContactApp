using System;
using System.Windows.Input;
using ContactApp.Models;
using ContactApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ContactApp.ViewModels
{
    internal class EditContactViewModel : BaseViewModel
    {
        private ICommand _addContact;
        private Contact _itemnew;


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

            Nav = new NavigationProxy();
            CurrentPage = new EditContact();
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new EditContact();
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

            Nav = navi;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new EditContact();
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

            Nav = navi;
            CurrentPage = page1;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new EditContact();
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

            CurrentPage = page1;
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = new EditContact();
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
            MessagingCenter.Send(this, "EditItem", _item);
            MessagingCenter.Send(this, "EditViewItem", _item);
            Nav.PopAsync();
        }
    }
}