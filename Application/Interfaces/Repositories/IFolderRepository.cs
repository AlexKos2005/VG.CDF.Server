using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
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
