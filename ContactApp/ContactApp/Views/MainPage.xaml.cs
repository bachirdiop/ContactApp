using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactApp.ViewModels;
using Xamarin.Forms;

namespace ContactApp
{
	public partial class MainPage : ContentPage
	{

		public MainPage(MainPageViewModel invm)
		{
		    var vm = invm;
		    vm.Nav = Navigation;

		    var p1 = new ContactViewModel(vm.Nav);
		    //p1.CurrentPage.BindingContext = p1;
            
		    vm.DisplayLoginPrompt += (s, s1) => DisplayAlert(s, s1, "OK");
		    vm.DisplayContactAction += () =>
		    {
		        p1.CurrentPage.Appearing += (sender, args) =>
		        {
		            base.OnAppearing();

		            if (p1.ListContact.Count == 0)
		                p1.LoadItemsCommand.Execute(null);
                }; 
		        NavigationPage.SetHasBackButton(p1.CurrentPage, false);
		        //NavigationPage.SetHasNavigationBar(p1.CurrentPage, false);
		        vm.Nav.PushAsync(p1.CurrentPage);
		        //Navigation.RemovePage(this);

		    };

		    BindingContext = vm;

            InitializeComponent();


		    NavigationPage.SetHasBackButton(this, false);
		    NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}
