using SQLite;

namespace NotasRapidas.Model.Entities
{
    public class Nota : ObservableBaseObject
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
