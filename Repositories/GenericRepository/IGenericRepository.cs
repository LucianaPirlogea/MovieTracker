

namespace MovieTracker.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity>
    {
        //GetData
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(int id);

        // Create

        void Create(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);

        // Update

        void Update(TEntity entity);

        // Delete

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        // Save
        Task<bool> SaveAsync();
    }
}
