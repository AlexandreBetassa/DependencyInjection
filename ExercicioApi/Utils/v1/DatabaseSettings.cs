using ExercicioApi.Contracts.v1;

namespace ExercicioApi.Utils.v1
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ContractCollectionName { get; set; }
        public string InstallmentCollectionName { get; set; }
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
