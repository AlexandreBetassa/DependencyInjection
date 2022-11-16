using ExercicioApi.Contracts.v1;
using ExercicioApi.Models.v1;
using MongoDB.Driver;

namespace ExercicioApi.Repositories.v1
{
    public class ContractRepository : IContractRepository
    {
        private readonly IDatabase<Contract> _contractRepository;

        public ContractRepository(IDatabaseSettings settings, IDatabase<Contract> database)
        {
            //var contract = new MongoClient(settings.ConnectionString);
            //var database = contract.GetDatabase(settings.DatabaseName);
            _contractRepository = database;
        }

        public Task<Contract> CreateAsync(Contract entity) => _contractRepository.CreateAsync(entity);

        public Task<Contract> DeleteAsync(Contract entity) => _contractRepository.DeleteAsync(entity);

        public Task<Contract> GetAsync(string id) => _contractRepository.GetAsync(id);

        public Task<List<Contract>> GetAsync() => _contractRepository.GetAsync();

        public Task<Contract> UpdateAsync(Contract entity) => _contractRepository.UpdateAsync(entity);
    }
}
