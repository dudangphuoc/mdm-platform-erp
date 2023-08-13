using System.ComponentModel;

namespace MDM.ModuleBase
{
    public enum EDataType
    {
        [Description("String")]
        String = 1,

        [Description("Integer")]
        Integer = 2,

        [Description("Bool")]
        Bool = 3,

        [Description("Double")]
        Double = 4,

        [Description("Datetime")]
        Datetime = 5
    }
}
