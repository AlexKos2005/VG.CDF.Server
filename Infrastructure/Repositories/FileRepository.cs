using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VG.CDF.Server.Application.Interfaces;
using VG.CDF.Server.Application.Interfaces.Repositories;
using VG.CDF.Server.Domain.Entities;
using File = VG.CDF.Server.Domain.Entities.File;


namespace VG.CDF.Server.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ISqlDataContext _sqlDataContext;

        public FileRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
        public async Task AddNewFileinFolderWithResult(File file)
        {
            await _sqlDataContext.Files.AddAsync(file);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task DeleteFileWithResult(File file)
        {
            var dbFile = await _sqlDataContext.Files.Where(p => p.Id == file.Id).FirstOrDefaultAsync();
            if (dbFile == null)
            {
                return;
            }
            _sqlDataContext.Files.Remove(dbFile);
            await _sqlDataContext.SaveChangesAsync();

        }

        public async Task<List<File>?> GetAllFilesWithResult()
        {
              var files = await _sqlDataContext.Files.ToListAsync();
              return files;
          
        }
    }
}
