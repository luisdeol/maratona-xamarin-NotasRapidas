using Microsoft.WindowsAzure.MobileServices;
using SQLite;

namespace NotasRapidas.Model.Entities
{
    [DataTable("Notas")]
    public class Nota : ObservableBaseObject
    {

        [PrimaryKey]
        public string Id { get; set; }

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set
            {
                _titulo = value;
                OnPropertyChanged();
            }
        }

        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Titulo;
        }

        [Version]
        public string AzureVersion { get; set; }
    }
}
