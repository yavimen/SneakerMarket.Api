using System;
using System.Collections.Generic;

namespace SneakerMarket.Api.Models;

public partial class ShoesAdditionalInfo
{
    public Guid Id { get; set; }

    public Guid ShoesMainId { get; set; }

    public float ShoesSize { get; set; }

    public float PricePerOne { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<OrderShoesInfoMap> OrderShoesInfoMaps { get; set; } = new List<OrderShoesInfoMap>();

    public virtual ShoesMain ShoesMain { get; set; } = null!;
}
