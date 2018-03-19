﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactApp.ViewModels;
using Xamarin.Forms;

namespace ContactApp
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

		    var vm = new MainPageViewModel();
		    vm.CurrentPage = new MainPage(vm);
            MainPage = new NavigationPage(vm.CurrentPage);
            
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
