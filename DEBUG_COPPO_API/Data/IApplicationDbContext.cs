using COMMON.Models;
using Microsoft.EntityFrameworkCore;
namespace DEBUG_COPPO_API.Data;

/// <summary>
/// A blue print of the <see cref="ApplicationDbContext"/> class used to access data from the database.
/// </summary>
public interface IApplicationDbContext
{
    /// <summary>
    /// Gets or sets <see cref="Log"/> data in the database.
    /// </summary>
    public DbSet<Log> Logs { get; set; }
}