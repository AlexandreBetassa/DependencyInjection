using Exercicio.Contracts;
using Exercicio.Models.v1;
using Exercicio.Repositories;
using Exercicio.Services.v1;
using System.Runtime.CompilerServices;

namespace Exercicio.Controllers.v1
{
    public class ContractController
    {
        private IContractService _service;

        public ContractController() { }

        public void NewContract()
        {
            _service = new ContractService(new PaypalService(), new ContractRepository());
            _service.NewContract();
        }
        public void Get()
        {
            _service = new ContractService(new ContractRepository());
            _service.Get();
        }

        public void GetOne()
        {
            _service = new ContractService(new ContractRepository());
            _service.GetOne();
        }

    }
}
