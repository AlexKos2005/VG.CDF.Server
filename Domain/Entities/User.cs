using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BreadCommunityWeb.Blz.Domain.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public User()
        {
            UsersFactories = new List<UserFactory>();
            Folders = new List<Folder>();
        }
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }

        public List<UserFactory> UsersFactories { get; set; }

        public List<Folder> Folders { get; set; }
    }
}
