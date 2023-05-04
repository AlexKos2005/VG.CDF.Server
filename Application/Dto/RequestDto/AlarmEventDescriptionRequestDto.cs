
namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class AlarmEventDescriptionRequestDto
    {
        public int Id { get; private set; }

        public string Description { get; set; }

        public int DescriptionsLanguageId { get; set; }

    }
}
