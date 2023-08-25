using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.CustomerModule.Models;
public class GetPartyTypeModel : IEntityDto<Guid>
{
    /// <summary>
    /// Id loại party (thực thể/ đối tượng).
    /// </summary>
    public Guid Id { get; set; }
}