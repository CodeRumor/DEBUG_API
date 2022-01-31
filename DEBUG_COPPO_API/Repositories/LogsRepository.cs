using CodeRumor.DataAccessLibrary.DbContext;
using COMMON.Models;

namespace DEBUG_COPPO_API.Repositories;
using CodeRumor.DataAccessLibrary.Repositories;

public class LogsRepository : BaseRepository<Log>
{
    public LogsRepository(
        IGeneralDbContext generalDbContext,
        ILogger<LogsRepository> logger) : base(generalDbContext, logger)
    {
    }
}