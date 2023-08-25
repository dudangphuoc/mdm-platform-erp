using MDM.ModuleBase;
using System.Text.Json.Serialization;

namespace MDM.CustomerModule.Models;

public class CreateAtttributeModel
{
    /// <summary>
    /// Id field.
    /// </summary>
    public Guid? AttributeId { get; set; }

    /// <summary>
    /// Tên field.
    /// </summary>
    public string? AttributeName { get; set; }

    /// <summary>
    /// Giá trị.
    /// </summary>
    public virtual string Value { get; set; }

    /// <summary>
    /// Loại dữ liệu.
    /// </summary>
    public EDataType DataType { get; set; }

    [JsonIgnore]
    public Guid EntityId { get; set; }
}