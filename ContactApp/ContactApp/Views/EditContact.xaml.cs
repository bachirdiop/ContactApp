using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditContact : ContentPage
	{
		public EditContact ()
		{
			InitializeComponent ();
		}
        
	    public EditContact(Object o)
	    {
	        BindingContext = o;
	        InitializeComponent();

	    }

	 
    }
}