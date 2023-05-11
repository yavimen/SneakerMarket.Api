using System;
using System.Collections.Generic;

namespace SneakerMarket.Api.Models;

public partial class CustomerInfo
{
    public Guid CustomerAccountId { get; set; }

    public float? CustomerDiscount { get; set; }

    public string? City { get; set; }

    public virtual Account CustomerAccount { get; set; } = null!;
}
