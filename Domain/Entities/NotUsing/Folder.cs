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
        public int Id { get; set; }
        public string Name { get; set; }

        public int FactoryId { get; set; }
        
        public Project Project { get; set; }

        public int UserId { get; set; }
        
        public User User { get; set; }

        public List<File> Files { get; set; }
    }
}
