namespace HanumanInstitute.EngageBayApi.Models;

/// <summary>
/// Represents an EngageBay property value.
/// </summary>
public class ApiPropertyValue
{
    /// <summary>
    /// The property name.
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// The property value.
    /// </summary>
    public string? Value { get; set; }
    
    /// <summary>
    /// The field type.
    /// </summary>
    public ApiFieldType? FieldType { get; set; }
    
    /// <summary>
    /// Whether the field data is searchable.
    /// </summary>
    public bool? IsSearchable { get; set; }
    
    /// <summary>
    /// The type of property: SYSTEM or CUSTOM.
    /// </summary>
    public ApiPropertyType? Type { get; set; }
    
    /// <summary>
    /// The property subtype, when multiple entries are allowed.
    /// </summary>
    public string? Subtype { get; set; }
}
