using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Domain.Entities
{ 
   public class TagLive
    {
        [Key]
        public long Id { get; set; }

        public int TagParamExternalId { get; set; }

        //Время фиксации
        public DateTime DateTime { get; set; }

        //Время фиксации в UTC
        public DateTimeOffset DateTimeOffset { get; set; }

        public int FactoryExternalId { get; set; }

        public int DeviceExternalId { get; set; }

        public string Value { get; set; }

        public TagValueTypeCodes ValueType { get; set; }

        public long TagsGroupId { get; set; }

        [ForeignKey(nameof(TagsGroupId))]
        public TagsGroup TagsGroup { get; set; }
    }
}
