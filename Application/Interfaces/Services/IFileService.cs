using BreadCommunityWeb.Blz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Interfaces.Services
{
    public interface IFileService
    {
        Task AddNewFileinFolderWithResult(File file);
        Task DeleteFileWithResult(File file);
    }
}
