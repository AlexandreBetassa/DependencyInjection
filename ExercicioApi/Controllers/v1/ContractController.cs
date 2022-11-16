using ExercicioApi.Contracts.v1;
using ExercicioApi.Models.v1;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioApi.Controllers.v1
{
    [Route("api/contract")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractRepository _repositoryContract;
        private readonly IInstallmentRepository _repositoryInstallments;

        public ContractController(IContractRepository repositoryContract, IInstallmentRepository repositoryInstallments)
        {
            _repositoryContract = repositoryContract;
            _repositoryInstallments = repositoryInstallments;
        }

        [HttpPost]
        public async Task<ActionResult<Contract>> Post([FromBody] Contract contract)
        {
            contract.Installments = await _repositoryInstallments.CreateManyAsync(contract.Installments);
            await _repositoryContract.CreateAsync(contract);
            return CreatedAtRoute("GetContract", new { numberContract = contract.Number }, contract);
        }

        [HttpGet]
        public async Task<ActionResult<List<Contract>>> Get() => await _repositoryContract.GetAsync();

        [HttpGet("{id}", Name = "GetContract")]
        public async Task<ActionResult<Contract>> Get(string id) => await _repositoryContract.GetAsync(id);
    }
}
