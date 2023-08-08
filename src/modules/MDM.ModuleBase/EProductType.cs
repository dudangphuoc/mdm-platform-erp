using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MDM.ModuleBase;

public enum EProductType
{
    [Display(Name = "Simple")]
    Simple = 1,

    [Display(Name = "Gift")]
    Gift = 2
}