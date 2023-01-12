using System;
using System.Collections.Generic;

namespace ECRUD.Models;

public partial class Person
{
    public string Idperson { get; set; } = null!;

    public string? Name { get; set; } = null!;

    public string? Lastname { get; set; } = null!;

    public DateTime? Borthdate { get; set; }

    public byte[]? UserPhoto { get; set; } = null!;

    public int? Status { get; set; }

    public bool? Brothers { get; set; }
}
