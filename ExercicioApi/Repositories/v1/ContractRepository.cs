using ExercicioApi.Contracts.v1;
using ExercicioApi.Models.v1;
using MongoDB.Driver;

namespace ExercicioApi.Repositories.v1
{
    public class ContractRepository : IContractRepository
    {
        private readonly IMongoCollection<Contract> _contractRepository;

        public ContractRepository(IDatabaseSettings settings)
        {
            var contract = new MongoClient(settings.ConnectionString);
            var database = contract.GetDatabase(settings.DatabaseName);
            _contractRepository = database.GetCollection<Contract>(settings.ContractCollectionName);
        }
        public async Task<Contract> Create(Contract contract) 
        {
            _contractRepository.InsertOne(contract);
            return await Task.FromResult(contract);
        }

        public void Delete(Contract contractIn) => _contractRepository.DeleteOne(contract => contract.Number == contractIn.Number);

        public Task<List<Contract>> Get() => _contractRepository.Find(contract => true).ToListAsync();

        public Task<Contract> GetContract(string numberContract) => _contractRepository.Find(contract => contract.Number == numberContract).FirstOrDefaultAsync();
    }
}
