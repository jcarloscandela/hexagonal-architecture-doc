using System.Collections.Generic;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Async Repository.
    /// </summary>
    /// <typeparam name="T">Clals of the repository.</typeparam>
    public interface IAsyncRepository<T>
        where T : class
    {
        /// <summary>
        /// Returns a list of all entities.
        /// </summary>
        /// <returns>List returned.</returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// Item by Id.
        /// </summary>
        /// <param name="id">id of the entity.</param>
        /// <returns>returns entity.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Add entity to the repository.
        /// </summary>
        /// <param name="entity">Entity to be added.</param>
        public void AddEntity(T entity);

        /// <summary>
        /// Update entity in memory.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        void UpdateEntity(T entity);
    }
}
