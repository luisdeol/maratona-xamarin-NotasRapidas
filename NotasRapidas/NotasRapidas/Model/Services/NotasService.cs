using Newtonsoft.Json;
using NotasRapidas.Model.Entities;
using NotasRapidas.Storage;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NotasRapidas.Model.Services
{
    public class NotasService
    {
        protected static string BaseUrl { get; set; } = "http://notasrapidasapi.azurewebsites.net/api/notas";

        public static NotasDirectory LoadNotas()
        {
            var dbManager = new DatabaseManager();
            var directory = new NotasDirectory();
            foreach (var nota in dbManager.GetItems())
            {
                directory.Notas.Add(nota);
            }
            return directory;
        }

        public static void AddNota(Nota nota)
        {
            var dbManager = new DatabaseManager();
            dbManager.SaveItem(nota);
        }

        protected static async Task<IEnumerable<Nota>> GetAsJson()
        {
            var result = Enumerable.Empty<Nota>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(BaseUrl).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        result = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Nota>>(json))
                        .ConfigureAwait(false);
                    }
                }
            }
            return result;
        }

        public static async Task<IEnumerable<Nota>> GetNotas()
        {
            return await GetAsJson();
        }
    }
}
