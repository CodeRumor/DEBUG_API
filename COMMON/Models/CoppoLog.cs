﻿using System.ComponentModel.DataAnnotations;
namespace COMMON.Models;

/// <summary>
/// A <see cref="CoppoLog"/> class which contains application logging information for the COPPO_API project.
/// </summary>
public class CoppoLog
{
    /// <summary>
    /// A unique identifier used to identity this <see cref="CoppoLog"/>.
    /// </summary>
    [Key]
    [Required]
    public int Id { get; }

    /// <summary>
    /// The information about this <see cref="CoppoLog"/>.
    /// </summary>
    public string? Message { get; set; }
    
    /// <summary>
    /// The structured representation of the message for this <see cref="CoppoLog"/>
    /// </summary>
    public string? MessageTemplate { get; set; }

    /// <summary>
    /// This is the serilog level for the <see cref="CoppoLog"/> event, they are six levels of serilog which are
    /// Verbose, debug, information, warning, Error and fatal. 
    /// </summary>
    public string? Level { get; set; } 
    
    /// <summary>
    /// The time in which the <see cref="CoppoLog"/> even occured.
    /// </summary>
    public DateTime TimeStamp { get; set; }
    
    /// <summary>
    /// The <see cref="Exception"/> if any contained by the current <see cref="CoppoLog"/>.
    /// </summary>
    public string? Exception { get; set; } 

    /// <summary>
    /// Describes a set of attributes that belong to a <see cref="CoppoLog"/>.
    /// </summary>
    public string? Properties { get; set; }
}