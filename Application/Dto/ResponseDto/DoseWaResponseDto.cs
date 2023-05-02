using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BreadCommunityWeb.Blz.Application.Dto.ResponseDto
{
   public class DoseWaResponseDto
    {
        [Key]
        public int Id { get; set; }

        public int FactoryExternalId { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public string IpDevice { get; set; }

        public string IpDeviceCode { get; set; }

        public string NameDevice { get; set; }

        public string NameOperator { get; set; }

        public int CodeOperator { get; set; }

        public string NameDosier { get; set; }

        public string BlowerBrand { get; set; }

        public string Power { get; set; }

        public string Pressure { get; set; }

        public string Productivity { get; set; }

        public string NameProduct { get; set; }

        public string RotaryFeeder { get; set; }

        public double Drive { get; set; }

        public double GearBox { get; set; }

        public double WorkProp_1 { get; set; }

        public double WorkProp_2 { get; set; }

        public double WorkProp_3 { get; set; }

        public double WorkProp_4 { get; set; }

        public double WorkProp_5 { get; set; }

        public double WorkProp_6 { get; set; }

        public double WorkProp_7 { get; set; }

        public double WorkProp_8 { get; set; }

        public double WorkProp_9 { get; set; }

        public double WorkProp_10 { get; set; }

        public double WorkProp_11 { get; set; }

        public double WorkProp_12 { get; set; }

        public double WorkProp_13 { get; set; }

        public double WorkProp_14 { get; set; }

        public double WorkProp_15 { get; set; }

        public double WorkProp_16 { get; set; }

        public double WorkProp_17 { get; set; }

        public double WorkProp_18 { get; set; }

        public double WorkProp_19 { get; set; }

        public double WorkProp_20 { get; set; }

        public double WorkProp_21 { get; set; }

        public double WorkProp_22 { get; set; }

        public double WorkProp_23 { get; set; }

        public double WorkProp_24 { get; set; }

        public double WorkProp_25 { get; set; }

        public double WorkProp_26 { get; set; }

        public double WorkProp_27 { get; set; }

        public double WorkProp_28 { get; set; }

        public double WorkProp_29 { get; set; }

        public double WorkProp_30 { get; set; }

        public double WorkProp_31 { get; set; }

        public double WorkProp_32 { get; set; }

        public double WorkProp_33 { get; set; }

        public double WorkProp_34 { get; set; }

        public double WorkProp_35 { get; set; }

        public double WorkProp_36 { get; set; }

        public double WorkProp_37 { get; set; }

        public double WorkProp_38 { get; set; }
    }
}
