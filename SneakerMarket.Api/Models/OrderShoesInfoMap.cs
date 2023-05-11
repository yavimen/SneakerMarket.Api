using System;
using System.Collections.Generic;

namespace SneakerMarket.Api.Models;

public partial class OrderShoesInfoMap
{
    public Guid Id { get; set; }

    public Guid AdditionalInfoId { get; set; }

    public Guid CustomerOrderId { get; set; }

    public virtual ShoesAdditionalInfo AdditionalInfo { get; set; } = null!;

    public virtual CustomerOrder CustomerOrder { get; set; } = null!;
}
