using ExercicioApi.Contracts.v1;
using ExercicioApi.Models.v1;
using MongoDB.Driver;

namespace ExercicioApi.Repositories.v1
{
    public class ContractRepositoryStub : IContractRepository
    {

        public ContractRepositoryStub()
        {
        }
        public async Task<Contract> Create(Contract contract)
        {
            return await Task.FromResult(contract);
        }

        public void Delete(Contract contractIn)
        { }

        public Task<List<Contract>> Get() => Task.FromResult(new List<Contract>());

        public Task<Contract> GetContract(string numberContract) => Task.FromResult(new Contract());
    }
}
