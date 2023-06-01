using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VG.CDF.Server.Domain.Entities
{
    public class File
    {
        public int Id { get; set; }
        public string FullFileName { get; set; }

        /// <summary>
        /// Прим.- .pdf
        /// </summary>
        public string FileExtention { get; set; }

        public byte[] FileBytes { get; set; }

        public int FolderId { get; set; }
        
        public Folder Folder { get; set; }

    }
}
