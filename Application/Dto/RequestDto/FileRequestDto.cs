using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
    public class FileRequestDto
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string FullPath { get; set; }

    }
}
