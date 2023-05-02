using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Domain.Entities
{
    public class ReportSchema
    {
        public ReportSchema()
        {
            TagReportsQueue = new List<TagParamReport>();
        }
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int DeviceId { get; set; }

        public string Description { get; set; }

        public List<TagParamReport> TagReportsQueue { get; set; }
    }
}
