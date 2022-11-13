using Exercicio.Models.v1;

namespace Exercicio.Contracts
{
    public interface IContractService : IService
    {
        public void ProcessContract(Contract contract, int month);
        public void NewContract();
        public void Get();
        public void GetOne();

    }
}
