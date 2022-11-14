using Exercicio.Models.v1;

namespace Exercicio.Contracts.v1
{
    public interface IContractService
    {
        public void ProcessContract(Contract contract, int month);
        public void NewContract();
        public void Get();
        public void GetOne();

    }
}
