using API_New.Models;
using API_New.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repository
{
    public class BarKeluarRepository
    {
        private readonly string request;
        private readonly HttpContextAccessor contextAccessor;
        private HttpClient httpClient;

        public BarKeluarRepository(string request = "BarKeluar/")
        {
            this.request = request;
            contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7209/api/")
            };
        }

        //Get All
        public async Task<ResponseDataVM<List<BarangKeluar>>> Get()
        {
            ResponseDataVM<List<BarangKeluar>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<BarangKeluar>>>(apiResponse);
            }
            return entityVM;
        }

        //Get by Id
        public async Task<ResponseDataVM<BarangKeluar>> Get(int id)
        {
            ResponseDataVM<BarangKeluar> entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<BarangKeluar>>(apiResponse);
            }
            return entity;
        }

        //Post - Create
        public async Task<ResponseDataVM<string>> Post(BarangKeluar barang)
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
        public async Task<ResponseDataVM<string>> Put(int id, BarangKeluar barang)
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
        public async Task<ResponseDataVM<BarangKeluar>> Delete(int id)
        {
            ResponseDataVM<BarangKeluar> entity = null;

            using (var response = await httpClient.DeleteAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<BarangKeluar>>(apiResponse);
            }
            return entity;
        }
    }
}
