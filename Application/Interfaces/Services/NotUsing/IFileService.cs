using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface IFileService
    {
        Task AddNewFileinFolderWithResult(File file);
        Task DeleteFileWithResult(File file);
    }
}
