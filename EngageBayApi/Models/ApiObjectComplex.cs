namespace HanumanInstitute.EngageBayApi.Models;

public class ApiObjectComplex : ApiObject
{
    /// <summary>
    /// Returned by search function.
    /// </summary>
    public long? Count { get; set; }
    
    /// <summary>
    /// Contains all extended properties of the object.
    /// </summary>
    public IList<ApiPropertyValue>? Properties { get; set; }
    
    protected string? GetPropertyValue(string name, bool custom, string? subtype = null) =>
        GetPropertyItem(name, custom, subtype)?.Value;

    protected T SetPropertyValue<T>(string name, string? value, ApiFieldType fieldType, bool custom, string? subtype = null)
        where T : ApiObjectComplex
    {
        var item = GetPropertyItem(name, custom, subtype);
        if (item != null)
        {
            item.Value = value;
            return (T)this;
        }
        item = new ApiPropertyValue
        {
            Name = name,
            Value = value,
            FieldType = fieldType,
            Type = GetPropertyType(custom),
            Subtype = subtype
        };
        Properties ??= new List<ApiPropertyValue>();
        Properties.Add(item);
        return (T)this;
    }

    private ApiPropertyValue? GetPropertyItem(string name, bool custom, string? subtype) =>
        Properties?.FirstOrDefault(x => x.Type == GetPropertyType(custom) && (subtype == null || x.Subtype == subtype) && x.Name == name);
    
    private ApiPropertyType GetPropertyType(bool custom) => 
        custom ? ApiPropertyType.Custom : ApiPropertyType.System;
}
