using System;
using System.Collections.Generic;

namespace SneakerMarket.Api.Models;

public partial class CustomerOrder
{
    public Guid Id { get; set; }

    public Guid CustomerAccountId { get; set; }

    public DateTime DateStamp { get; set; }

    public virtual Account CustomerAccount { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderShoesInfoMap> OrderShoesInfoMaps { get; set; } = new List<OrderShoesInfoMap>();
}
