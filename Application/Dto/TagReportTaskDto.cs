using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreadCommunityWeb.Blz.Domain.Enums;

namespace BreadCommunityWeb.Blz.Application.Dto
{
    public class TagReportTaskDto
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }

        public bool IsActive { get; set; }

        public DateTime? LastSendDt { get; set; }
        
        public  ReportTaskStatus Status { get; set; }
        
    }
}
