using NotasRapidas.Model.Entities;
using System.Collections.ObjectModel;

namespace NotasRapidas.Model.Services
{
    public class NotasService
    {
        public static NotasDirectory LoadNotas()
        {
            var directory = new NotasDirectory();

            var notas = new ObservableCollection<Nota>() { 
                new Nota { Description = "Pei pow", Title = "sei la o que"},
                new Nota { Description = "Pei pow", Title = "sei la o que" },
                new Nota { Description = "Pei pow", Title = "sei la o que" }
            };
            directory.Notas = notas;
            return directory;
        }
    }
}
