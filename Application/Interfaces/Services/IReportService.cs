using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface IReportService<T>
    {
        T MakeReport();
    }
}
