using NotasRapidas.Model.Entities;
using NotasRapidas.Model.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        public NotasViewModel()
        {
            Notas = new ObservableCollection<Nota>();
            IsBusy = false;
            LoadDirectoryCommand = new Command(obj=> LoadDirectory())
;        }

        public async void LoadDirectory()
        {
            if (!IsBusy)
            {
                IsBusy = true;
                await Task.Delay(3000);
                var notasDirectory = await NotasService.LoadNotas();
                foreach (var nota in notasDirectory.Notas)
                    Notas.Add(nota);
                IsBusy = false;
            }
        }
    }
}
