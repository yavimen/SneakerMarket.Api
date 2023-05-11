using System;
using System.Collections.Generic;

namespace SneakerMarket.Api.Models;

public partial class Account
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Guid RoleId { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual CustomerInfo? CustomerInfo { get; set; }

    public virtual AccountRole Role { get; set; } = null!;
}
