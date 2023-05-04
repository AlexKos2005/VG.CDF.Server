using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace VG.CDF.Server.Application.Dto.RequestDto
{
   public class FolderRequestDto
    {
        public int Id { get; private set; }

        public ICollection<FileRequestDto> Files { get; set; } = new List<FileRequestDto>();
        public string Name { get; set; }
    }
}
