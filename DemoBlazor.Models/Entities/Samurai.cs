﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DemoBlazor.Models.Entities;

public partial class Samurai
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? ClanId { get; set; }

    public virtual Clan Clan { get; set; }

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();
}