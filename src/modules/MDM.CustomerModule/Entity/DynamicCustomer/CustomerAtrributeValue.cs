﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MDM.Common.EntityFactory;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CustomerModule.Entity.DynamicCustomer
{
    [InjectContext]
    public class CustomerAtrributeValue : CreationAuditedEntity<Guid>, IPassivable
    {
        public Guid? EntityId { get; set; } = Guid.Empty;

        public Guid AttributeId { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string Value { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public CustomerAttribute Attribute { get; set; }
    }
}
