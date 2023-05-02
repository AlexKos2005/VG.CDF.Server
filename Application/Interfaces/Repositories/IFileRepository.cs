using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Repositories
{
   public interface IFileRepository
    {
        Task AddNewFileinFolderWithResult(File file);
        Task DeleteFileWithResult(File file);
    }
}
