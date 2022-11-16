namespace ExercicioApi.Contracts.v1
{
    public interface IDatabase<T> where T : IEntity
    {
        public Task<T> GetAsync(string id);
        public Task<List<T>> GetAsync();
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(T entity);
    }
}
