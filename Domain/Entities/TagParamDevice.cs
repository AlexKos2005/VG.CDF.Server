using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BreadCommunityWeb.Blz.Domain.Entities
{
    [Index(nameof(TagParamId), nameof(DeviceId), IsUnique = true)]
    public class TagParamDevice
    {
        [Key]
        public int Id { get; set; }
        public int TagParamId { get; set; }
        public TagParam TagParam { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }

    }
}
