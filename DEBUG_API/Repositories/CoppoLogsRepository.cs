using CodeRumor.DataAccessLibrary.DbContext;
using CodeRumor.DataAccessLibrary.Repositories;
using COMMON.Models;

namespace DEBUG_API.Repositories;

/// A concrete <see cref="CoppoLogsRepository"/> class for accessing <see cref="CoppoLog"/> data from the database.
public class CoppoLogsRepository : BaseRepository<CoppoLog>
{
    /// <summary>
    /// Initialises the class of the <see cref="CoppoLogsRepository"/>.
    /// </summary>
    /// <param name="generalDbContext">A context that provides a way to read data from the database.</param>
    /// <param name="logger">Logs the status of the current <see cref="CoppoLogsRepository"/> processes.</param>
    public CoppoLogsRepository(
        IGeneralDbContext generalDbContext,
        ILogger<CoppoLogsRepository> logger) : base(generalDbContext, logger)
    {
    }
}