
namespace VG.CDF.Server.Application.Dto.ResponseDto
{
    public class AlarmEventDescriptionResponseDto
    {
        public int Id { get; private set; }

        public string Description { get; set; }

        public int DescriptionsLanguageId { get; set; }

        public AlarmEventResponseDto AlarmEvent { get; set; }
        public LanguageResponseDto DescriptionsLanguage { get; set; }
    }
}
