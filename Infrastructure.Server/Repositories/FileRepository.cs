using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BreadCommunityWeb.Blz.Application.Interfaces.Repositories;
using BreadCommunityWeb.Blz.Infrastructure.Server.DataContext;
using BreadCommunityWeb.Blz.Domain.Entities;

namespace BreadCommunityWeb.Blz.Infrastructure.Server.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly SqlDataContext _sqlDataContext;

        public FileRepository(SqlDataContext sqlDataContext)
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
            _sqlDataContext.Remove(dbFile);
            await _sqlDataContext.SaveChangesAsync();

        }

        public async Task<List<File>?> GetAllFilesWithResult()
        {
              var files = await _sqlDataContext.Files.ToListAsync();
              return files;
          
        }
    }
}
