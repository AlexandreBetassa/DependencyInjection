namespace ExercicioApi.Contracts.v1
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task Delete(T entity);
        Task<List<T>> Get();
    }
}
