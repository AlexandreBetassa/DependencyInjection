namespace ExercicioApi.Contracts.v1
{
    public interface IRepository<IEntity>
    {
        Task<IEntity> Create(IEntity entity);
        void Delete(IEntity entity);
        Task<List<IEntity>> Get();
    }
}
