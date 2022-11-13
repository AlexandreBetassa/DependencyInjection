using Exercicio.Contracts;
using Exercicio.Models.v1;
using System.Text;
using System.Text.Json;

namespace Exercicio.Repositories
{
    public class ContractRepository : IContractRepository
    {
        public ContractRepository() { }

        public async Task<bool> Create(Contract contract)
        {
            using (HttpClient contractRepository = new HttpClient())
            {
                string jsonContract = JsonSerializer.Serialize(contract);
                HttpContent content = new StringContent(jsonContract, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await contractRepository.PostAsync("https://localhost:7197/api/contract/", content);
                return response.IsSuccessStatusCode ? true : false;
            }
        }

        public async Task<Contract?> Get(string numberContract)
        {
            using (HttpClient contractRepository = new HttpClient())
            {
                HttpResponseMessage response = await contractRepository.GetAsync($"https://localhost:7197/api/contract/{numberContract}/");
                var jsonContract = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<Contract>(jsonContract) : null;
            }
        }

        public async Task<List<Contract>> Get()
        {
            using (HttpClient contractRepository = new HttpClient())
            {
                HttpResponseMessage response = await contractRepository.GetAsync($"https://localhost:7197/api/contract");
                var jsonContract = await response.Content.ReadAsStringAsync();
                return response.IsSuccessStatusCode ? JsonSerializer.Deserialize<List<Contract>>(jsonContract) : null;

            }
        }
    }
}
