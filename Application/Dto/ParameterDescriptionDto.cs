
using System;

namespace VG.CDF.Server.Application.Dto
{
    public class ParameterDescriptionDto : EntityBaseDto
    {
        public string RusDescription { get; set; }
        
        public string EngDescription { get; set; }
        
        public string UkrDescription { get; set; }

        public Guid LanguageId { get; set; }

        public Guid ParameterId { get; set; }

    }
}
