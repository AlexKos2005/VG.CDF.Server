using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace VG.CDF.Server.Application.Dto.ResponseDto
{
   public class FolderResponseDto
    {
        public int Id { get; set; }
        public ICollection<FileResponseDto> Files { get; set; } = new List<FileResponseDto>();
        public string Name { get; set; }
    }
}
