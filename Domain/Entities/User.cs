﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VG.CDF.Server.Domain.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User : EntityBase
    {
        public User()
        {
            UsersFactories = new List<UserProject>();
            Folders = new List<Folder>();
        }
        [Key]
        public override Guid Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Guid RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }

        public List<UserProject> UsersFactories { get; set; }

        public List<Folder> Folders { get; set; }
    }
}
