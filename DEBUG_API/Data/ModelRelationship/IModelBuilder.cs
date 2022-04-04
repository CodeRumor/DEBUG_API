using Microsoft.EntityFrameworkCore;

namespace DEBUG_API.Data.ModelRelationship;

/// <summary>
/// Defines the behaviour of the classes used to build relationships between entities in the database.
/// </summary>
public interface IModelBuilder
{
    /// <summary>
    /// Build relationship between entities for the database
    /// </summary>
    /// <param name="modelBuilder">
    /// The builder being used to construct the model for this context.
    /// </param>
    public void Build(ModelBuilder modelBuilder);
}