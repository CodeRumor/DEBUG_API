using COMMON.Models;
using Microsoft.EntityFrameworkCore;
namespace DEBUG_COPPO_API.Data;

/// <summary>
/// A blue print of the <see cref="ApplicationDbContext"/> class that provides a context used to query data from the
/// database.
/// </summary>
public interface IApplicationDbContext
{
    /// <summary>
    /// Gets or sets <see cref="CoppoLog"/> data in the database.
    /// </summary>
    public DbSet<CoppoLog>? CoppoLogs { get; set; }
}