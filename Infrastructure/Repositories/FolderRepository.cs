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
    public class FolderRepository : IFolderRepository
    {
        private readonly ISqlDataContext _sqlDataContext;

        public FolderRepository(ISqlDataContext sqlDataContext)
        {
            _sqlDataContext = sqlDataContext;
        }
        public async Task DeleteFolderWithResult(Folder folder)
        {
            var dbFolder = await _sqlDataContext.Folders.Where(p => p.Id == folder.Id).FirstOrDefaultAsync();
            _sqlDataContext.Folders.Remove(dbFolder);
            await _sqlDataContext.SaveChangesAsync();
        }

        public async Task<List<Folder>?> GetAllFoldersWithResult()
        {
            var folders = await _sqlDataContext.Folders.ToListAsync();
            return folders;
        }

        public async Task<Folder?> GetFolderByIdWithResult(int folderId)
        {
            var folder = await _sqlDataContext.Folders.Where(p => p.Id == folderId).FirstOrDefaultAsync();
            return folder;
        }

        public async Task<List<Folder>?> GetFoldersByFactoryExternalIdWithResult(int factoryUid)
        {
            var folders = await _sqlDataContext.Folders.Where(p => p.FactoryId == factoryUid).ToListAsync();
            return folders;
        }

        public async Task SetNewFolderWithResult(Folder folder)
        {
            await _sqlDataContext.Folders.AddAsync(folder);
            await _sqlDataContext.SaveChangesAsync();

        }


        public async Task<List<File>?> GetFilesByFolderIdWithResult(int folderId)
        {
            var files = await _sqlDataContext.Folders.Where(c => c.Id == folderId).FirstOrDefaultAsync();
            return files.Files.ToList();
        }
    }
}

