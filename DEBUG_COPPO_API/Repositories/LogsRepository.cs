using CodeRumor.DataAccessLibrary.DbContext;
using COMMON.Models;

namespace DEBUG_COPPO_API.Repositories;
using CodeRumor.DataAccessLibrary.Repositories;

public class LogsRepository : BaseRepository<Log>
{
    /// <summary>
    /// A concrete <see cref="LogsRepository"/> class for accessing <see cref="Log"/> data from the database.
    /// </summary>
    /// <param name="generalDbContext">A context that provides a way to read data from the database</param>
    /// <param name="logger">Logs the status of the current <see cref="LogsRepository"/> processes.</param>
    public LogsRepository(
        IGeneralDbContext generalDbContext,
        ILogger<LogsRepository> logger) : base(generalDbContext, logger)
    {
    }
}