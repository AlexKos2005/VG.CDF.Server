using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace VG.CDF.Server.Domain.Entities
{
    public class Role : EntityBase
    {
        public string RoleName { get; set; }

        public RoleCode RoleCode { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
