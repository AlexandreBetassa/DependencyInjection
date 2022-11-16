using ExercicioApi.Contracts.v1;
using ExercicioApi.Models.v1;

namespace ExercicioApi.Repositories.v1
{
    public class InstallmentRepository : IInstallmentRepository
    {
        private readonly IDatabase<Installment> _database;

        public InstallmentRepository(IDatabase<Installment> database) => _database = database;

        public Task<Installment> CreateAsync(Installment entity) => _database.CreateAsync(entity);

        public Task<List<Installment>> CreateManyAsync(List<Installment> entity) => _database.CreateManyAsync(entity);

        public Task<Installment> DeleteAsync(Installment entity) => _database.DeleteAsync(entity);

        public Task<Installment> GetAsync(string id) => _database.GetAsync(id);

        public Task<List<Installment>> GetAsync() => _database.GetAsync();

        public Task<Installment> UpdateAsync(Installment entity) => _database.UpdateAsync(entity);
    }
}
