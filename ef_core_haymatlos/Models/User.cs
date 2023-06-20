using System;
using System.Collections.Generic;

namespace ef_core_haymatlos.Models;

public partial class User
{
    public int Id { get; set; }

    public string Uuid { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>(); //lazy loading https://www.learnentityframeworkcore.com/lazy-loading
}
