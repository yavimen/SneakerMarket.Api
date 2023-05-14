using System;
using System.Collections.Generic;

namespace SneakerMarket.Api.Models;

public partial class Feedback
{
    public Guid Id { get; set; }

    public string? Feedback1 { get; set; }

    public Guid CustomerContactId { get; set; }

    public int CustomerRated { get; set; }

    public Guid CustomerOrderId { get; set; }

    public DateTime? Date { get; set; }

    public virtual Contact CustomerContact { get; set; } = null!;

    public virtual CustomerOrder CustomerOrder { get; set; } = null!;
}
