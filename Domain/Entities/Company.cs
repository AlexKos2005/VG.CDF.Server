using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VG.CDF.Server.Domain.Entities;

public class Company
{
    public Company()
    {
        Projects = new HashSet<Project>();
    }
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<Project> Projects { get; set; }
}