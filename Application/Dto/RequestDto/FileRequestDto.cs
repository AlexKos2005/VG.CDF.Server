using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class FileRequestDto
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string FullPath { get; set; }

    }
}
