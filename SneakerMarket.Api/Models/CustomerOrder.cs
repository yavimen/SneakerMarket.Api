using System;
using System.Collections.Generic;

namespace SneakerMarket.Api.Models;

public partial class CustomerOrder
{
    public Guid Id { get; set; }

    public string CustomerAccountId { get; set; } = null!;

    public DateTime DateStamp { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderShoesInfoMap> OrderShoesInfoMaps { get; set; } = new List<OrderShoesInfoMap>();
}
