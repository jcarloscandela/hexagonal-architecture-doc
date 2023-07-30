namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Async Repository.
    /// </summary>
    /// <typeparam name="T">Clals of the repository.</typeparam>
    public interface IAsyncRepository<in T>
        where T : class
    {
        /// <summary>
        /// Add entity.
        /// </summary>
        /// <param name="entity">entity to create.</param>
        public void AddEntity(T entity);
    }
}
