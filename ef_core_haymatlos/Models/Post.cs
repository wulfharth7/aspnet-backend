using System;
using System.Collections.Generic;

namespace ef_core_haymatlos.Models;

public partial class Post
{
    public string Owner { get; set; } = null!;

    public string? Title { get; set; }

    public string? Text { get; set; }

    public string? Image { get; set; }

    public int? Id { get; set; }

    public string Uuid { get; set; } = null!;

    public string[]? Tag { get; set; }

    public int? Like { get; set; }

    public virtual User? OwnerNavigation { get; set; } = null!;  //lazy loading https://www.learnentityframeworkcore.com/lazy-loading
}
