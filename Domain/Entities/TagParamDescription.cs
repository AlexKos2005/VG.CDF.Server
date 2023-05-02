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
    [Index(nameof(TagParamId), nameof(DescriptionsLanguageId), IsUnique = true)]
    public class TagParamDescription
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public int TagParamId { get; set; }

        [ForeignKey(nameof(TagParamId))]
        public TagParam TagParam { get; set; }

        public int DescriptionsLanguageId { get; set; }

        [ForeignKey(nameof(DescriptionsLanguageId))]
        public DescriptionsLanguage DescriptionsLanguage { get; set; }
    }
}
