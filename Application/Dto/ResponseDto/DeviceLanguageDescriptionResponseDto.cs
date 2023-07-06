
using VG.CDF.Server.Domain.Entities;
using VG.CDF.Server.Domain.Enums;

namespace VG.CDF.Server.Application.Dto.ResponseDto
{
    public class DeviceLanguageDescriptionResponseDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public LanguageAcronyms Language { get; set; }

    }
}
