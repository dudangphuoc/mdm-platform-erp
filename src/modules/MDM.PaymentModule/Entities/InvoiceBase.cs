﻿using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.PaymentModule.Entities;

public abstract class InvoiceBase<TReference> : MDMFullAuditedEntityBase
{
    [Column(TypeName = "varchar(50)")]
    public string InvoiceCode { get; set; }

    public DateTime InvoiceDate { get; set; }

    public EInvoiceStatus InvoiceStatus { get; set; }

    [DataType("decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string Note { get; set; }
  
    public virtual TReference Order { get; set; }

    
}
