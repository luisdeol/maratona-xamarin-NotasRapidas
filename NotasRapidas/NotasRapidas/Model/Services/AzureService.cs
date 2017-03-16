using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotasRapidas.Model.Services
{
    public class AzureService<T>
    {
        IMobileServiceClient Client;
        public IMobileServiceTable<T> Table;

        public AzureService()
        {
            var myAppServiceUrl = "http://notasrapidasxamarin.azurewebsites.net";
            Client = new MobileServiceClient(myAppServiceUrl);
            Table = Client.GetTable<T>();
        }

        public Task<IEnumerable<T>> GetTable()
        {
            return Table.ToEnumerableAsync();
        }
    }
}
