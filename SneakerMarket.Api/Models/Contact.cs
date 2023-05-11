using System;
using System.Collections.Generic;

namespace SneakerMarket.Api.Models;

public partial class Contact
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public Guid AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Contract> ContractPmcontacts { get; set; } = new List<Contract>();

    public virtual ICollection<Contract> ContractSupplierContacts { get; set; } = new List<Contract>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
