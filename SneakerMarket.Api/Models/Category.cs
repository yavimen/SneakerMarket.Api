using System;
using System.Collections.Generic;

namespace SneakerMarket.Api.Models;

public partial class Category
{
    public Guid Id { get; set; }

    public string Category1 { get; set; } = null!;

    public virtual ICollection<ShoesMain> ShoesMains { get; set; } = new List<ShoesMain>();
}
