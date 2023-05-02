using BreadCommunityWeb.Blz.Application.Dto.RequestDto;
using BreadCommunityWeb.Blz.Application.Dto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IFolderService
    {
        Task SetNewFolderWithResult(FactoryResponseDto folder);
        Task<List<FactoryResponseDto>?> GetFoldersByFactoryExternalIdWithResult(int factoryExternalId);
        Task<FactoryResponseDto?> GetFolderByIdWithResult(int folderId);
        Task<List<FactoryResponseDto>?> GetAllFoldersWithResult();
        Task<List<FileResponseDto>?> GetFilesByFolderIdWithResult(int folderId);
        Task DeleteFolderWithResult(FolderRequestDto folderDto);
    }
}
