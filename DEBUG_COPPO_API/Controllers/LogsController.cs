using CodeRumor.DataAccessLibrary.Controllers;
using CodeRumor.DataAccessLibrary.DbContext;
using CodeRumor.DataAccessLibrary.Repositories;
using COMMON.Models;
using Microsoft.AspNetCore.Mvc;

namespace DEBUG_COPPO_API.Controllers;

/// <summary>
/// Provides methods used to access data from the database.
/// </summary>
[ApiController]
[Route("[controller]")]
public class LogsController : BaseController<Log, Log>
{
    
    /// <summary>
    /// Initialises a <see cref="LogsController"/> class.
    /// </summary>
    /// <param name="baseRepository">Services that provides data from the repository.</param>
    /// <param name="logger">A logger for logging errors as they occur.</param>
    public LogsController(IBaseRepository<Log> baseRepository, ILogger<BaseController<Log, Log>> logger) :
        base(baseRepository, logger)
    {
    }
}