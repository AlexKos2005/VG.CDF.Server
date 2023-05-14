using System;

namespace VG.CDF.Server.Domain.Entities;

public abstract class EntityBase
{
    public  virtual Guid Id { get; set; }
}