using CodeRumor.DataAccessLibrary.DbContext;
using COMMON.Models;
using DEBUG_API.Data.ModelRelationship;
using Microsoft.EntityFrameworkCore;

namespace DEBUG_API.Data;

/// <summary>
/// An implementation of the <see cref="ApplicationDbContext"/> class used to access data from the database.
/// </summary>
public class ApplicationDbContext : GeneralDbContext, IApplicationDbContext
{
    /// <summary>
    /// Initialises an instance of the <see cref="ApplicationDbContext"/> class.
    /// </summary>
    /// <param name="options">
    /// Carries the configuration information needed to configure the <see cref="DbContext"/>.
    /// </param>
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    /// <summary>
    /// This method is called when the model for a derived context has been initialized and is used to create
    /// relationships between models.
    /// </summary>
    /// <param name="modelBuilder">
    /// Provides an API which is used to configure the shape, data type and relationship between models.
    /// </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        CoppoLogModelBuilder.Instance.Build(modelBuilder);
    }
    
    /// <inheritdoc/>
    public DbSet<CoppoLog>? CoppoLogs { get; set; }
}