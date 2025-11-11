using System;
using System.Collections.Generic;

namespace demo1.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public bool? Admin { get; set; }

    public bool? Userdefault { get; set; }

    public bool? Banned { get; set; }
}
