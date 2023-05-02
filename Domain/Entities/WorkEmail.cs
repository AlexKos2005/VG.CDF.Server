using BreadCommunityWeb.Blz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Domain.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class WorkEmail
    {
        public WorkEmail()
        {
            TagReportTasks = new List<TagReportTask>();
        }
        [Key]
        public int Id { get; set; }
        
        public string Email { get; set; }
        
        public ICollection<TagReportTask> TagReportTasks { get; set; }

    }
}
