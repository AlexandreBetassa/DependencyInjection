using ExercicioApi.Contracts.v1;
using ExercicioApi.Models.v1;
using ExercicioApi.Repositories.v1;
using MongoDB.Driver;

namespace ExercicioApi.Utils.v1
{
    public static class Service
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services)
        {
            var connectionString = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase("ContractsDb");
            var collection = database.GetCollection<Contract>(nameof(Contract));

            services.AddSingleton<IMongoClient>(mongoClient); //uma unica instancia enquanto a aplicacao esta rodando
            services.AddScoped<IBaseRepository<Contract>, BaseRepository<Contract>>(); //cada request que for efetuada ele cria uma nova conexao
            return services;
        }
    }
}
