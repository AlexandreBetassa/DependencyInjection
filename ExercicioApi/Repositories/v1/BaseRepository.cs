using ExercicioApi.Contracts.v1;
using MongoDB.Driver;

namespace ExercicioApi.Repositories.v1
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _repository;

        public BaseRepository(IMongoCollection<T> repository) => _repository = repository;

        public async Task<T> Create(T entity)
        {
            await _repository.InsertOneAsync(entity);
            return entity;
        }

        public async Task Delete(T entity) => await Task.FromResult(_repository.DeleteOne(entityOut => entityOut.Equals(entity)));

        public async Task<List<T>> Get() => _repository.Find(item => true).ToList();

    }
}
