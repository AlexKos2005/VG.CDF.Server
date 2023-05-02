using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BreadCommunityWeb.Blz.Application.Dto.ResponseDto
{
    public class FileResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }

    }
}
