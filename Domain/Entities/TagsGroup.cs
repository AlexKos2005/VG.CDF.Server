using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Domain.Entities
{
    public class TagsGroup
    {
        public TagsGroup()
        {
            TagsLive = new List<TagLive>();
        }
        [Key]
        public long Id { get; set; }

        //Время фиксации
        public DateTime DateTime { get; set; }

        //Время фиксации по UTC
        public DateTimeOffset DateTimeOffset { get; set; }

        public int FactoryExternalId { get; set; }

        public int DeviceExternalId { get; set; }

        public List<TagLive> TagsLive { get; set; }
    }
}
