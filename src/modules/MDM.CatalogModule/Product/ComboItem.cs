using MDM.ModuleBase;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.CatalogModule.Product;

[Table(nameof(MDM.CatalogModule.Product.ComboItem))]
public class ComboItem : MDMFullAuditedEntityBase
{
    public Guid ComboProductId { get; set; }

    public Guid ProductId { get; set; }

    private float _quantity { get;set; }

    public float Quantity { get => _quantity; set => _quantity = value > 0 ? value : 0; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }

    [ForeignKey(nameof(ComboProductId))]
    public ComboProductItem ComboProductItem { get; set; }
}
