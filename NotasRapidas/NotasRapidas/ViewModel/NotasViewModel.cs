using NotasRapidas.Model.Entities;
using NotasRapidas.Model.Services;
using NotasRapidas.View;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace NotasRapidas.ViewModel
{
    public class NotasViewModel : ObservableBaseObject
    {
        public ObservableCollection<Nota> Notas { get; set; }
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public Command LoadDirectoryCommand { get; set; }
        public Command NewNoteCommand { get; set; }
        public INavigation Navigation { get; set; }

        public NotasViewModel(INavigation navigation)
        {
            Notas = new ObservableCollection<Nota>();
            IsBusy = false;
            LoadDirectoryCommand = new Command(obj=> LoadDirectory());
            NewNoteCommand = new Command(obj=> OpenNewNote());
            Navigation = navigation;
        }

        public async void OpenNewNote()
        {
            await Navigation.PushModalAsync(new CreateNewNote());
        }
        public void LoadDirectory()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                //await Task.Delay(3000);
                var notasDirectory = NotasService.LoadNotas();
                foreach (var nota in notasDirectory.Notas)
                    Notas.Add(nota);
                IsBusy = false;
            }
        }
    }
}
