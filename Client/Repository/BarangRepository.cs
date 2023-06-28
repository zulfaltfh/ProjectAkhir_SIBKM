using API_New.Models;
using API_New.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repository
{
    public class BarangRepository
    {
        private readonly string request;
        private readonly HttpContextAccessor contextAccessor;
        private HttpClient httpClient;

        public BarangRepository(string request = "Barang/")
        {
            this.request = request;
            contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7209/api/")
            };
        }

        //Get All
        public async Task<ResponseDataVM<List<Barang>>> Get()
        {
            ResponseDataVM<List<Barang>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<Barang>>>(apiResponse);
            }
            return entityVM;
        }

        //Get by Id
        public async Task<ResponseDataVM<Barang>> Get(string id)
        {
            ResponseDataVM<Barang> entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Barang>>(apiResponse);
            }
            return entity;
        }

        //Post - Create
        public async Task<ResponseDataVM<string>> Post(Barang barang)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(barang), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }

        //Put - Edit
        public async Task<ResponseDataVM<string>> Put(string id, Barang barang)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(barang), Encoding.UTF8, "application/json");
            using (var response = httpClient.PutAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }

        //Delete
        public async Task<ResponseDataVM<Barang>> Delete(string id)
        {
            ResponseDataVM<Barang> entity = null;

            using (var response = await httpClient.DeleteAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Barang>>(apiResponse);
            }
            return entity;
        }
    }
}
