using BreadCommunityWeb.Blz.Application.Interfaces.Repositories;
using BreadCommunityWeb.Blz.Domain.Entities;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Repositories
{
    public class ReportSchemaRepository : IReportSchemaRepository
    {
        private readonly SqlDataContext _sqlDataContext;
        public ReportSchemaRepository(SqlDataContext sqlDataContext)
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

        public async Task<List<TagParamReport>> GetAllReportSchemas(int userId, int deviceId)
        {
            var result = await _sqlDataContext.ReportSchemas.Where(c => c.UserId == userId && c.DeviceId == deviceId).FirstOrDefaultAsync();
            return result.TagReportsQueue;
        }

        public async Task Save(ReportSchema entity)
        {
            await _sqlDataContext.ReportSchemas.AddAsync(entity);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<bool> SaveTagReportQueue(int reportSchemaId, TagParamReport tagsReportQueue)
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

        public async Task<bool> SaveTagsReportQueue(int reportSchemaId,List<TagParamReport> tagReportsQueue)
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

        public async Task<bool> UpdateTagReportQueue(int tagReportId, int reportSchemaId, TagParamReport tagReportsQueue)
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
