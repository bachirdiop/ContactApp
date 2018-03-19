using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContact : ContentPage
    {
        public EditContact()
        {
            InitializeComponent();
        }

        public EditContact(object o)
        {
            BindingContext = o;
            InitializeComponent();
        }
    }
}