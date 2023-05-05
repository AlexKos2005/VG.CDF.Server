using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VG.CDF.Server.Domain.Entities
{
   public class Folder
    {
        public Folder()
        {
            Files = new List<File>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int FactoryId { get; set; }

        [ForeignKey(nameof(FactoryId))]
        public Project Project { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public List<File> Files { get; set; }
    }
}
