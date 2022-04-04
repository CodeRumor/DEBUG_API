using COMMON.Models;
using Microsoft.EntityFrameworkCore;

namespace DEBUG_API.Data.ModelRelationship;

/// <summary>
/// 
/// </summary>
public class CoppoLogModelBuilder : IModelBuilder
{
    private CoppoLogModelBuilder(){}
    
    /// <summary>
    /// Gets a single instance of the <see cref="CoppoLogModelBuilder"/>.
    /// </summary>
    public static CoppoLogModelBuilder Instance { get; } = new();
    
    /// <inheritdoc/>
    public void Build(ModelBuilder modelBuilder)
    {
        // create a Logs table with auto id.
        modelBuilder.Entity<CoppoLog>().ToTable("CoppoLogs");
        modelBuilder.Entity<CoppoLog>().Property(log => log.Id).ValueGeneratedOnAdd();
        
        modelBuilder.Entity<CoppoLog>(entity =>
        {
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });
    }
}