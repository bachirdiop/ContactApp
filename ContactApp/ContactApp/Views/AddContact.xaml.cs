using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContact : ContentPage
    {
        public AddContact()
        {
            InitializeComponent();
        }

        public AddContact(object o)
        {
            BindingContext = o;
            InitializeComponent();
        }
    }
}