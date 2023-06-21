using System;
using System.Collections.Generic;

namespace ef_core_haymatlos.Models;

public partial class User1
{
    public int Id { get; set; }

    public string Uuid { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Post1> Post1s { get; set; } = new List<Post1>();
}
