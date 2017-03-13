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
        public string Title { get; set; }
        public string Description { get; set; }

        public CreateNoteViewModel(INavigation navigation)
        {
            _navigation = navigation;
            AddNoteCommand = new Command(obj => AddNote(new Nota
            {
                Description = Description,
                Title = Title
            }));
        }

        public async void AddNote(Nota nota)
        {
            NotasService.AddNota(nota);
            await _navigation.PushModalAsync(new MainPage());
        }
    }
}
