using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class DescriptionsLanguageRequestDto
    {
        public int Id { get; private set; }

        public int LanguageExternalId { get; set; }
        public string LanguageLabel { get; set; }
    }
}
