using NotasRapidas.ViewModel;
using Xamarin.Forms;

namespace NotasRapidas.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new NotasViewModel();
        }
    }
}
