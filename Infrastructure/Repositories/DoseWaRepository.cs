using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Configurations;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Infrastructure.DataContext;


namespace VG.CDF.Server.Infrastructure.Repositories
{
    public class DoseWaRepository : IDoseWaRepository
    {
        private ISqlDataContext _sqlDataContext;
        private IDbConnectionConfig _dbConnectionConfig;

        public DoseWaRepository(IDbConnectionConfig dbConnectionConfig)
        {
            _dbConnectionConfig = dbConnectionConfig;
        }
        public async Task<List<DoseWa>> GetDosesWaByEnterpriseUIdAndDatesWithResult(int factoryExternalId, string ip, string code, DateTime startDate, DateTime endDate)
        {
            using (_sqlDataContext = new SqlDataContext(_dbConnectionConfig))
            {
                var result = await _sqlDataContext.DosesWa
                    .Where(p => p.FactoryExternalId == factoryExternalId && p.IpDevice == ip && p.IpDeviceCode == code && p.Date.Date >= startDate.Date && p.Date.Date <= endDate.Date)
                    .ToListAsync();

                return result;
            }
            
        }

        public async Task<List<DoseWa>> GetDosesWaWithResult(int factoryExternalId)
        {
            using (_sqlDataContext = new SqlDataContext(_dbConnectionConfig))
            {
                var result = await _sqlDataContext.DosesWa.Where(p => p.FactoryExternalId == factoryExternalId).ToListAsync();
                return result;
            }
        }


        public async Task SetDosesWaWithResult(List<DoseWa> dosesWa)
        {
            using (_sqlDataContext = new SqlDataContext(_dbConnectionConfig))
            {
                await _sqlDataContext.DosesWa.AddRangeAsync(dosesWa);
                await _sqlDataContext.SaveChangesAsync();
            }

        }
    }
}
