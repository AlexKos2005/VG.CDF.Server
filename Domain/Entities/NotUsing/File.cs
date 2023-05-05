using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VG.CDF.Server.Domain.Entities
{
    [Index(nameof(FolderId), nameof(FullFileName), IsUnique = true)]
    public class File
    {
        [Key]
        public int Id { get; set; }
        public string FullFileName { get; set; }

        /// <summary>
        /// Прим.- .pdf
        /// </summary>
        public string FileExtention { get; set; }

        public byte[] FileBytes { get; set; }

        public int FolderId { get; set; }

        [ForeignKey(nameof(FolderId))]
        public Folder Folder { get; set; }

    }
}
