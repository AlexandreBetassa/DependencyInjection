namespace ExercicioApi.Contracts.v1
{
    public interface IRepository<IEntity>
    {
        Task<IEntity> CreateAsync(IEntity entity);
        Task<IEntity> DeleteAsync(IEntity entity);
    }
}
