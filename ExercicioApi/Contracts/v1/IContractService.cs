using ExercicioApi.Models.v1;

namespace ExercicioApi.Contracts.v1
{
    public interface IContractService : IBaseRepository<Contract>
    {
        Contract GetContract(string numberContract);
    }
}
