namespace ExercicioApi.Contracts.v1
{
    public interface IDatabaseSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
