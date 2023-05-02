using BreadCommunityWeb.Blz.Domain.Enums;
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
    [Index(nameof(ExternalId), IsUnique = true)]
    public class TagParam
    {
        public TagParam()
        {
            TagsDevices = new List<TagParamDevice>();
            TagDescriptions = new List<TagParamDescription>();
            TagParamReports = new List<TagParamReport>();
        }
        [Key]
        public int Id { get; set; }

        public int ExternalId { get; set; }

        public TagValueTypeCodes ValueType { get; set; }

        public int ParameterGroupId { get; set; }

        [ForeignKey(nameof(ParameterGroupId))]
        public ParameterGroup ParameterGroup { get; set; }

        public List<TagParamDevice> TagsDevices { get; set; }
        public List<TagParamDescription> TagDescriptions { get; set; }

        public List<TagParamReport> TagParamReports { get; set; }
    }
}
