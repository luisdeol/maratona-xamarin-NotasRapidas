using NotasRapidas.ViewModel;
using Xamarin.Forms;

namespace NotasRapidas.View
{
    public partial class CreateNewNote : ContentPage
    {
        public CreateNewNote()
        {
            InitializeComponent();
            BindingContext = new CreateNoteViewModel(Navigation);
        }
    }
}
