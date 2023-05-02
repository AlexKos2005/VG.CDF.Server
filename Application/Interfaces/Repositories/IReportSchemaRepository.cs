using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
{
    public interface IReportSchemaRepository : ICrud<ReportSchema,int>
    {
        Task<List<TagParamReport>> GetAllReportSchemas(int userId, int deviceId);
        Task<bool> SaveTagsReportQueue(int reportSchemaId, List<TagParamReport> tagsReportQueue);

        Task<bool> SaveTagReportQueue(int reportSchemaId, TagParamReport tagsReportQueue);

        Task<bool> UpdateTagReportQueue(int tagReportId, int reportSchemaId, TagParamReport tagReportsQueue);
    }
}
