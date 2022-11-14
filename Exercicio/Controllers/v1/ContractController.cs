using Exercicio.Contracts.v1;

namespace Exercicio.Controllers.v1
{
    public class ContractController
    {
        private readonly IContractService _service;

        public ContractController(IContractService service) => _service = service;

        public void NewContract() => _service.NewContract();

        public void Get() => _service.Get();

        public void GetOne() => _service.GetOne();

    }
}
