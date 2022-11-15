using ExercicioApi.Contracts.v1;
using ExercicioApi.Models.v1;
using MongoDB.Driver;

namespace ExercicioApi.Serivce.v11
{
    public class ContractService : IContractService
    {
        private readonly IBaseRepository<Contract> _repository;

        public ContractService(IBaseRepository<Contract> repository) => _repository = repository;

        public Task<Contract> Create(Contract entity) => _repository.Create(entity);

        public Task Delete(Contract entity) => _repository.Delete(entity);

        public Task<List<Contract>> Get() => Task.FromResult(_repository.Get().Result);

        public Contract? GetContract(string numberContract)
        {
            return Get().Result.FirstOrDefault(item => item.Number == numberContract);
        }
    }
}
