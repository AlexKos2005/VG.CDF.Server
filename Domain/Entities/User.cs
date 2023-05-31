using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VG.CDF.Server.Domain.Entities
{
    public class User : EntityBase
    {

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Guid RoleId { get; set; }
        
        public Role Role { get; set; }

        public ICollection<UserProject> UserProjects { get; set; }

        public ICollection<Folder> Folders { get; set; }
    }
}
