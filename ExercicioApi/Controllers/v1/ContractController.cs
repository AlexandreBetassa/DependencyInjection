using ExercicioApi.Contracts.v1;
using ExercicioApi.Models.v1;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioApi.Controllers.v1
{
    [Route("api/contract")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _repositoryContract;

        public ContractController(IContractService repositoryContract) => _repositoryContract = repositoryContract;

        [HttpPost]
        public async Task<ActionResult<Contract>> Post([FromBody] Contract contract)
        {
            await _repositoryContract.Create(contract);
            return CreatedAtRoute("GetContract", new { numberContract = contract.Number }, contract);
        }

        [HttpGet]
        public async Task<ActionResult<List<Contract>>> Get() => await _repositoryContract.Get();

        [HttpGet("{numberContract}", Name = "GetContract")]
        public async Task<ActionResult<Contract>> Get(string numberContract) => _repositoryContract.GetContract(numberContract);
    }
}
