using NotasRapidas.Model.Entities;
using NotasRapidas.Storage;
using System.Collections.ObjectModel;
using System.Linq;

namespace NotasRapidas.Model.Services
{
    public class NotasService
    {
        public static NotasDirectory LoadNotas()
        {
            DatabaseManager dbManager = new DatabaseManager();
            ObservableCollection<Nota> notas = new ObservableCollection<Nota>(dbManager.GetItems());

            var directory = new NotasDirectory();
            if (notas.Any())
            {
                directory.Notas = notas;
                return directory;
            }

            notas = new ObservableCollection<Nota>() { 
                new Nota { Description = "Pei pow", Title = "sei la o que"},
                new Nota { Description = "Pei pow 2", Title = "sei la o que 2" },
                new Nota { Description = "Pei pow 3", Title = "sei la o que 3" }
            };

            directory.Notas = notas;
            foreach(var nota in notas)
                dbManager.SaveItem(nota);

            return directory;
        }
    }
}
