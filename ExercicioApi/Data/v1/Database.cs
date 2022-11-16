using ExercicioApi.Contracts.v1;
using MongoDB.Driver;

namespace ExercicioApi.Data.v1
{
    public class Database<T> : IDatabase<T> where T : IEntity
    {
        private readonly IMongoCollection<T> _collection;
        public Database(IDatabaseSettings settings)
        {
            var mongoConnection = new MongoClient(settings.ConnectionString);
            var database = mongoConnection.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<T> CreateAsync(T entity)
        {
            _collection.InsertOne(entity);
            return await Task.FromResult(entity);
        }

        public async Task<List<T>> CreateManyAsync(List<T> entity)
        {
            _collection.InsertMany(entity);
            return await Task.FromResult(entity);
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _collection.DeleteOne(entityOut => entityOut.Id == entity.Id);
            return await Task.FromResult(entity);
        }

        public async Task<T> GetAsync(string id) => await _collection.Find(entityOut => entityOut.Id == id).FirstOrDefaultAsync();

        public async Task<List<T>> GetAsync() => await _collection.Find(entity => true).ToListAsync();

        public async Task<T> UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync(entityIn => entityIn.Id == entity.Id, entity);
            return await Task.FromResult(entity);
        }
    }
}
