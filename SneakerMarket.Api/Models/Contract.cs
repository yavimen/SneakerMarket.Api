using System;
using System.Collections.Generic;

namespace SneakerMarket.Api.Models;

public partial class Contract
{
    public Guid Id { get; set; }

    public Guid SupplierContactId { get; set; }

    public Guid PmcontactId { get; set; }

    public DateTime DateStamp { get; set; }

    public virtual Contact Pmcontact { get; set; } = null!;

    public virtual ICollection<ShoesMain> ShoesMains { get; set; } = new List<ShoesMain>();

    public virtual Contact SupplierContact { get; set; } = null!;
}
