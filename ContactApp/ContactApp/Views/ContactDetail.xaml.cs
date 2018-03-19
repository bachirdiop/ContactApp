using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ContactDetail (ContactDetailViewModel lastval = null, Contact lastvalct = null)
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

		    DisplayDeletePrompt += delegate(Contact contact)
		    {
		        string actdel = DisplayActionSheet("Supress", "Cancel Supress", "Supress Item", "yes").Result;
		                      DisplayAlert("test", actdel, "yes");
            };


            MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditViewItem", (obj, item) =>
		    {
		        //var _item = item as Contact;
		        //BindingContext = _item;
		    });

		    InitializeComponent();
        }

	    public ContactDetail(Object o, ContactViewModel lastval = null)
	    {
	        BindingContext =  o;

	        InitializeComponent();

	        MessagingCenter.Subscribe<EditContactViewModel, Contact>(this, "EditViewItem", (obj, item) =>
	        {
	            //var _item = item as Contact;
	            //BindingContext = _item;
	        });

            DisplayDeletePrompt += delegate (Contact contact)
	        {
	            string actdel = DisplayActionSheet("Supress", "Cancel Supress", "Supress Item", "yes").Result;
	                          DisplayAlert("test", actdel, "yes");
	        };

        }
    }
}