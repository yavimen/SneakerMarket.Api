using System;
using System.Collections.Generic;

namespace SneakerMarket.Api.Models;

public partial class ShoesMain
{
    public Guid Id { get; set; }

    public string ShoesName { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public float Discount { get; set; }

    public Guid ContractId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Contract Contract { get; set; } = null!;

    public virtual ICollection<ShoesAdditionalInfo> ShoesAdditionalInfos { get; set; } = new List<ShoesAdditionalInfo>();
}
