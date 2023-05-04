
namespace VG.CDF.Server.Application.Dto.ResponseDto
{
    public class DeviceDescriptionResponseDto
    {
        public int Id { get;  set; }

        public string Description { get; set; }

        public int DeviceId { get; set; }

        public int DescriptionsLanguageId { get; set; }

        public LanguageResponseDto DescriptionsLanguage { get; set; }
    }
}
