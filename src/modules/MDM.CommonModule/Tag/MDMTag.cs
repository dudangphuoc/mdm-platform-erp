using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CommonModule.Tag;
public class MDMTag : MDMFullAuditedEntityBase
{
    [Column(TypeName = "nvarchar(256)")]
    public string Name { get; set; }

    [Column(TypeName = "nvarchar(512)")]
    public string Description { get; set; }
}
