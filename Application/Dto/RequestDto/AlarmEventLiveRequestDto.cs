﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
    public class AlarmEventLiveRequestDto
    {
        public long Id { get; private set; }

        public int ExternalId { get; set; }

        //Время фиксации
        public DateTime DateTime { get; set; }

        //Время фиксации в UTC
        public DateTimeOffset DateTimeOffset { get; set; }

        public int FactoryExternalId { get; set; }

        public int DeviceExternalId { get; set; }
    }
}
