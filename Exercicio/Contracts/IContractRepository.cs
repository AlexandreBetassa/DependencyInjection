
using Exercicio.Models.v1;

namespace Exercicio.Contracts
{
    public interface IContractRepository
    {
        public Task<List<Contract>> Get();
        public Task<Contract> Get(string numberContract);
        public Task<bool> Create(Contract contract);

    }
}
