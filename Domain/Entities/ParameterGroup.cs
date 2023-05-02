using BreadCommunityWeb.Blz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Domain.Entities
{
    [Index(nameof(ParameterGroupExternalId), IsUnique = true)]
    public class ParameterGroup
    {
        public ParameterGroup()
        {
            Tags = new List<TagParam>();
        }
        [Key]
        public int Id { get; set; }

        public int ParameterGroupExternalId { get; set; }

        public string Name { get; set; }

        public List<TagParam> Tags { get; set; }
    }
}
