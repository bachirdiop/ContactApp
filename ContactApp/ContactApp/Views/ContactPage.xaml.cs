using ContactApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        public ContactPage(ContactViewModel invm)
        {
            var vm = invm;
            BindingContext = vm;

            InitializeComponent();
        }
    }
}