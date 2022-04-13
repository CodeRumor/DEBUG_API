using DEBUG_API.Data;
using Microsoft.EntityFrameworkCore;

namespace DEBUG_API.Utilities.DbMigration;

/// <summary>
/// A class the create the migration for the <see cref="DEBUG_API"/> application.
/// </summary>
public static class DebugApiMigration
{
    /// <summary>
    /// Performs migration if the database doesn't exit.
    /// </summary>
    /// <param name="applicationDbContext">
    /// A <see cref="ApplicationDbContext"/> class used to access data from the database.
    /// </param>
    /// <param name="logger">
    /// A logger that logs any exceptions the occur.
    /// </param>
    public static void Create(ApplicationDbContext? applicationDbContext, ILogger? logger)
    {
        try
        {
            if (applicationDbContext != null)
            {
                applicationDbContext.Database.Migrate();
            }
            else
            {
                throw new Exception("Couldn't create Migration applicationDbContext might be null!");
            }
        }
        catch (Exception error)
        {
            logger?.LogError("{Message}", error.Message);
        }
    }
}