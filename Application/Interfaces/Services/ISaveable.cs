using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Services;

public interface ISaveable<T> where T: class
{
    Task<bool> Save(IEnumerable<T> parameterValuesGroups);
}