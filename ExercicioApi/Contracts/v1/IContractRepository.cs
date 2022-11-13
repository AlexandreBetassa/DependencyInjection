using ExercicioApi.Models.v1;

namespace ExercicioApi.Contracts.v1
{
    public interface IContractRepository : IRepository<Contract>
    {
        Task<Contract> GetContract(string numberContract);
    }
}
