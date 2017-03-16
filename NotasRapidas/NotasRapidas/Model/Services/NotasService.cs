using Newtonsoft.Json.Linq;
using NotasRapidas.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasRapidas.Model.Services
{
    public class NotasService
    {
        protected static string BaseUrl { get; set; } = "http://notasrapidasapi.azurewebsites.net/api/notas";

        public static async Task<NotasDirectory> LoadNotas()
        {
            var directory = new NotasDirectory();
            var notas = await GetNotas();
            foreach (var nota in notas)
            {
                directory.Notas.Add(nota);
            }
            return directory;
        }

        public static async void AddNota(Nota nota)
        {
            var jo = new JObject
            {
                {"id", Guid.NewGuid().ToString("N")},
                {"Titulo", nota.Titulo},
                {"Descripcion", nota.Descripcion}
            };
            var service = new AzureService<Nota>();
            var notas = service.Table;
            await notas.InsertAsync(jo);
        }

        public static async Task<List<Nota>> GetNotas()
        {
            var service = new AzureService<Nota>();
            var notas = await service.GetTable();
            return notas.ToList();
        }


        //protected static async Task<IEnumerable<Nota>> GetAsJson()
        //{
        //    var result = Enumerable.Empty<Nota>();
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        var response = await client.GetAsync(BaseUrl).ConfigureAwait(false);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        //            if (!string.IsNullOrWhiteSpace(json))
        //            {
        //                result = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Nota>>(json))
        //                .ConfigureAwait(false);
        //            }
        //        }
        //    }
        //    return result;
        //}

        //public static async Task<IEnumerable<Nota>> GetNotas()
        //{
        //    return await GetAsJson();
        //}
    }
}
