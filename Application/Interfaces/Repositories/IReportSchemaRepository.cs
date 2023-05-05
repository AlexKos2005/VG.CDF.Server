using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
    public interface IReportSchemaRepository : ICrud<ReportSchema,int>
    {
        Task<List<ParameterReport>> GetAllReportSchemas(int userId, int deviceId);
        Task<bool> SaveTagsReportQueue(int reportSchemaId, List<ParameterReport> tagsReportQueue);

        Task<bool> SaveTagReportQueue(int reportSchemaId, ParameterReport tagsReportQueue);

        Task<bool> UpdateTagReportQueue(int tagReportId, int reportSchemaId, ParameterReport tagReportsQueue);
    }
}
