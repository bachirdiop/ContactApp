using System;
using ContactApp.Models;
using ContactApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetail : ContentPage
    {
        public Action<Contact> DisplayDeletePrompt;

        public ContactDetail(ContactDetailViewModel lastval = null, Contact lastvalct = null)
        {
            //Contact res;

            //ContactDetailViewModel ct = lastval ?? new ContactDetailViewModel(lastval.Nav ?? Navigation,lastvalct);

            //      ct.DisplayDeletePrompt += delegate(Contact contact)
            //      {
            //          res = contact as Contact;
            //          ct = new ContactDetailViewModel(lastval.Nav?? Navigation, res);
            //          ct.DisplayDeletePrompt += delegate(Contact contact1)
            //          {
            //              string actdel = DisplayActionSheet("Supress", "Cancel Supress", "Supress Item", "yes").Result;
            //              DisplayAlert("test", actdel, "yes");
            //          };

            //          //ct.Itemnew = res;
            //          //ct.CurrentPage = new ContactDetail();
            //          //ct.OpenPage();
            //          //ct.CurrentPage.BindingContext = ct;

            //      };

            DisplayDeletePrompt += delegate
            {
                var actdel = DisplayActionSheet("Supress", "Cancel Supress", "Supress Item", "yes").Result;
                DisplayAlert("test", actdel, "yes");
            };


            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditViewItem", (obj, item) =>
            {
                //var _item = item as Contact;
                //BindingContext = _item;
            });

            InitializeComponent();
        }

        public ContactDetail(object o, ContactViewModel lastval = null)
        {
            BindingContext = o;

            InitializeComponent();

            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditViewItem", (obj, item) =>
            {
                //var _item = item as Contact;
                //BindingContext = _item;
            });

            DisplayDeletePrompt += delegate
            {
                var actdel = DisplayActionSheet("Supress", "Cancel Supress", "Supress Item", "yes").Result;
                DisplayAlert("test", actdel, "yes");
            };
        }
    }
}