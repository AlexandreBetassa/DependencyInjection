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

        public async Task<Contract> CreateAsync(Contract entity)
        {
            _contractRepository.InsertOne(entity);
            return await Task.FromResult(entity);
        }

        public async Task<Contract> DeleteAsync(Contract entity)
        {
            await _contractRepository.DeleteOneAsync(contract => contract.Id == entity.Id);
            return await Task.FromResult(entity);
        }

        public async Task<Contract> GetAsync(string id) => await _contractRepository.Find(entity => entity.Id == id).FirstOrDefaultAsync();

        public async Task<List<Contract>> GetAsync() => await _contractRepository.Find(contract => true).ToListAsync();

        public async Task<Contract> UpdateAsync(Contract entity)
        {
            await _contractRepository.ReplaceOneAsync(entityIn => entityIn.Id == entity.Id, entity);
            return await Task.FromResult(entity);
        }
    }
}
