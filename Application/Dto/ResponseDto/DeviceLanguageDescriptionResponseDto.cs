
using VG.CDF.Server.Domain.Entities;

namespace VG.CDF.Server.Application.Dto.ResponseDto
{
    public class DeviceLanguageDescriptionResponseDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public LanguageDescriptionCodes Language { get; set; }

    }
}
