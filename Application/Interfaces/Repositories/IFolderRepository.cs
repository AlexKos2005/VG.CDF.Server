using System.Collections.Generic;
using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
   public interface IFolderRepository
    {
        Task SetNewFolderWithResult(Folder folder);
        Task<List<Folder>?> GetFoldersByFactoryExternalIdWithResult(int factoryExternalId);
        Task<Folder?> GetFolderByIdWithResult(int folderId);
        Task<List<Folder>?> GetAllFoldersWithResult();
        Task<List<File>?> GetFilesByFolderIdWithResult(int folderId);
        Task DeleteFolderWithResult(Folder folderDto);
    }
}
