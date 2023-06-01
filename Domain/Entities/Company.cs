using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VG.CDF.Server.Domain.Entities;

public class Company: EntityBase
{
    public string Name { get; set; }

    public virtual ICollection<Project> Projects { get; set; }
    
    public virtual ICollection<Parameter> Parameters { get; set; }
    
    public virtual ICollection<AlarmEvent> AlarmEvents { get; set; }
}