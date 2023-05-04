using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
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
