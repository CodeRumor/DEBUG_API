using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace COMMON.Models;

/// <summary>
/// A <see cref="Log"/> class which contains application logging information for the COPPO_API project.
/// </summary>
public sealed class Log
{
    /// <summary>
    /// A unique identifier used to identity this <see cref="Log"/>.
    /// </summary>
    [Key]
    [Required]
    public int Id { get; set; }

    /// <summary>
    /// The information about this <see cref="Log"/>.
    /// </summary>
    [DefaultValue("N-A")]
    public string Message { get; set; } = "N-A";

    /// <summary>
    /// This is the serilog level for the <see cref="Log"/> event, they are six levels of serilog which are
    /// Verbose, debug, information, warning, Error and fatal. 
    /// </summary>
    [DefaultValue("N-A")]
    public string Level { get; set; } = "N-A";
    
    /// <summary>
    /// The time in which the <see cref="Log"/> even occured.
    /// </summary>
    public DateTime TimeStamp { get; set; }
    
    /// <summary>
    /// The <see cref="Exception"/> if any contained by the current <see cref="Log"/>.
    /// </summary>
    [DefaultValue("N-A")]
    public string Exception { get; set; } = "N-A";

    /// <summary>
    /// Describes a set of attributes that belong to a <see cref="Log"/>.
    /// </summary>
    [DefaultValue("N-A")]
    public string Properties { get; set; } = "N-A";
}