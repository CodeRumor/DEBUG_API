namespace DEBUG_COPPO_API.Repositories;

/// <summary>
/// A blue print of the <see cref="BaseRepository"/> class that contains methods used to obtain data from the
/// database.
/// </summary>
public interface IBaseRepository<TModel> where TModel : class
{
    /// <summary>
    /// Get all <see typeparamref ="IEnumerable{TModel}"/>s.
    /// </summary>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken "/>to observe while waiting for the task to complete.
    /// </param>
    /// <returns>
    /// A <see cref="Task"/> that returns all <see typeparamref ="TModel"/> models or null if none are found
    /// or if there is an error.
    /// </returns>
    public Task<IEnumerable<TModel>> GetAllAsync(CancellationToken cancellationToken = default);
}