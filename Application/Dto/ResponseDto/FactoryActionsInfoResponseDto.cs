using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VG.CDF.Server.Application.Dto.ResponseDto
{
    public class FactoryActionsInfoResponseDto
    {
        public int Id { get; set; }

        public DateTime LastDateTimeConnection { get; set; }

        public DateTime LastDateTimeReportSending { get; set; }

        public DateTimeOffset LastDateTimeConnectionOffset { get; set; }

        public DateTimeOffset LastDateTimeReportSendingOffset { get; set; }

        public int AlarmMessageCounter { get; set; }

    }
}
