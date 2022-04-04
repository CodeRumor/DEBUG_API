using CodeRumor.DataAccessLibrary.Controllers;
using CodeRumor.DataAccessLibrary.Repositories;
using COMMON.Models;
using Microsoft.AspNetCore.Mvc;

namespace DEBUG_API.Controllers;

/// <summary>
/// Provides methods used to access data from the database.
/// </summary>
[ApiController]
[Route("[controller]")]
public class CoppoLogsController : BaseController<CoppoLog, CoppoLog>
{
    
    /// <summary>
    /// Initialises a <see cref="CoppoLogsController"/> class.
    /// </summary>
    /// <param name="baseRepository">Services that provides data from the repository.</param>
    /// <param name="logger">A logger for logging errors as they occur.</param>
    public CoppoLogsController(IBaseRepository<CoppoLog> baseRepository, ILogger<CoppoLogsController> logger) :
        base(baseRepository, logger)
    {
    }
}