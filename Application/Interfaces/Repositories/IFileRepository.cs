using System.Threading.Tasks;
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Interfaces.Repositories
{
   public interface IFileRepository
    {
        Task AddNewFileinFolderWithResult(File file);
        Task DeleteFileWithResult(File file);
    }
}
