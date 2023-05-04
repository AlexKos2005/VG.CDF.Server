using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface IReportSchemaService : ICrudService<ReportSchemaRequestDto, ReportSchemaResponseDto, int>
    {
        Task<List<DevicesReportSchemasResponseDto>> GetAllReportSchemas(int userId, int factoryId);
        Task<bool> SaveTagsReportQueue(int reportSchemaId, List<TagParamReportRequestDto> tagsReportQueue);

        Task<bool> SaveTagReportQueue(int reportSchemaId, TagParamReportRequestDto tagReportQueue);

        Task<bool> UpdateTagReportQueue(int tagReportId, int reportSchemaId, TagParamReportRequestDto tagReportsQueue);

        Task<bool> UpdateTagReportQueues(int reportSchemaId, List<TagParamReportRequestDto> tagReportsQueue);
    }
}
