﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DemoBlazor.Models.Entities;

public partial class Quote
{
    public int Id { get; set; }

    public string Text { get; set; }

    public int SamuraiId { get; set; }

    public virtual Samurai Samurai { get; set; }
}