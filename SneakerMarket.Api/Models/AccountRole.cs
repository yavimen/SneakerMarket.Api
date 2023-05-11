using System;
using System.Collections.Generic;

namespace SneakerMarket.Api.Models;

public partial class AccountRole
{
    public Guid Id { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
