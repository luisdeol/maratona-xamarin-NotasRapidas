using System.Collections.ObjectModel;

namespace NotasRapidas.Model.Entities
{
    public class NotasDirectory : ObservableBaseObject
    {
        private ObservableCollection<Nota> _notas = new ObservableCollection<Nota>();

        public ObservableCollection<Nota> Notas
        {
            get { return _notas; }
            set { _notas = value;
                OnPropertyChanged();
            }
        }
    }
}
