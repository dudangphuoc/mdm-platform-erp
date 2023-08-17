using MDM.CatalogModule.Entity.Base;
using MDM.Common.EntityFactory;

namespace Identity.Core.Entities;

[InjectContext]
public class ProductGift : ProductGiftBase<Product, Gift>
{
    public Guid ProductId { get; set; }

    public Guid GiftId { get; set; }

}
