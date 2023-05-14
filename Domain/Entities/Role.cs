using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace VG.CDF.Server.Domain.Entities
{
    [Index(nameof(RoleCode), IsUnique = true)]
    public class Role : EntityBase
    {
        public Role()
        {
            Users = new List<User>();
        }
        [Key]
        public override Guid Id { get; set; }
        
        public string RoleName { get; set; }

        public RoleCodes RoleCode { get; set; }

        public List<User> Users { get; set; }
    }
}
