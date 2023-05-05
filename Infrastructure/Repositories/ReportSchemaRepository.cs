
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Infrastructure.Repositories
{
    public class ReportSchemaRepository : IReportSchemaRepository
    {
        private readonly ISqlDataContext _sqlDataContext;
        public ReportSchemaRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
        public async Task Delete(int id)
        {
            var reportSchema = await _sqlDataContext.ReportSchemas.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (reportSchema == null)
            {
                return;
            }

            _sqlDataContext.ReportSchemas.Remove(reportSchema);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<ReportSchema?> Get(int id)
        {
            return await _sqlDataContext.ReportSchemas.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ParameterReport>> GetAllReportSchemas(int userId, int deviceId)
        {
            var result = await _sqlDataContext.ReportSchemas.Where(c => c.UserId == userId && c.DeviceId == deviceId).FirstOrDefaultAsync();
            return result.TagReportsQueue;
        }

        public async Task Save(ReportSchema entity)
        {
            await _sqlDataContext.ReportSchemas.AddAsync(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<bool> SaveTagReportQueue(int reportSchemaId, ParameterReport tagsReportQueue)
        {
            var reportSchema = await _sqlDataContext.ReportSchemas.Where(c => c.Id == reportSchemaId).FirstOrDefaultAsync();
            if (reportSchema == null)
            {
                return false;
            }

            reportSchema.TagReportsQueue.Add(tagsReportQueue);
            await _sqlDataContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SaveTagsReportQueue(int reportSchemaId,List<ParameterReport> tagReportsQueue)
        {
            var reportSchema = await _sqlDataContext.ReportSchemas.Where(c => c.Id == reportSchemaId).FirstOrDefaultAsync();
            if(reportSchema == null)
            {
                return false;
            }

            reportSchema.TagReportsQueue.AddRange(tagReportsQueue);
            await _sqlDataContext.SaveChangesAsync();

            return true;
        }

        public async Task<ReportSchema?> Update(int id, ReportSchema entity)
        {
            var reportSchema = await _sqlDataContext.ReportSchemas.Where(c => c.Id == id).FirstOrDefaultAsync();
            if(reportSchema == null)
            {
                return null;
            }

            reportSchema.Description = entity.Description;
            reportSchema.DeviceId = entity.DeviceId;
            reportSchema.UserId = entity.UserId;
            _sqlDataContext.ReportSchemas.Update(reportSchema);

            await _sqlDataContext.SaveChangesAsync();

            return reportSchema;
        }

        public async Task<bool> UpdateTagReportQueue(int tagReportId, int reportSchemaId, ParameterReport tagReportsQueue)
        {
            var reportSchema = await _sqlDataContext.ReportSchemas.Where(c => c.Id == reportSchemaId).FirstOrDefaultAsync();
            if (reportSchema == null)
            {
                return false;
            }

            var tagReport = reportSchema.TagReportsQueue.Where(c => c.Id == tagReportId).FirstOrDefault();
            if (tagReport == null)
            {
                return false;
            }

            tagReport.NumberInQueue = tagReportsQueue.NumberInQueue;

            _sqlDataContext.TagReportQueues.Update(tagReport);

            return true;
        }
    }
}
