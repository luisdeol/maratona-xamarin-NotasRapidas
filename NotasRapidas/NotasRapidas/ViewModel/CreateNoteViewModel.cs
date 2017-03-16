using NotasRapidas.Model.Entities;
using NotasRapidas.Model.Services;
using NotasRapidas.View;
using Xamarin.Forms;

namespace NotasRapidas.ViewModel
{
    public class CreateNoteViewModel
    {
        private readonly INavigation _navigation;
        public Command AddNoteCommand { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public CreateNoteViewModel(INavigation navigation)
        {
            _navigation = navigation;
            AddNoteCommand = new Command(obj => AddNote(new Nota
            {
                Descripcion = Descripcion,
                Titulo = Titulo
            }));
        }

        public async void AddNote(Nota nota)
        {
            NotasService.AddNota(nota);
            await _navigation.PushModalAsync(new MainPage());
        }
    }
}
