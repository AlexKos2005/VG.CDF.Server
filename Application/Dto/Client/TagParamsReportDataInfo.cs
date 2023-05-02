﻿using BreadCommunityWeb.Blz.Application.Dto.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.Client
{
    public class TagParamsReportDataInfo
    {
        public int FactoryId { get; set; }

        public int LanguageExternalId { get; set; }

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public List<DeviceTagParamsResponseDto> DeviceTagParams { get; set; }
    }
}