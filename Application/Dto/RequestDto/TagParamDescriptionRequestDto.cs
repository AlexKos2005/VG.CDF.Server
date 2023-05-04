
namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class TagParamDescriptionRequestDto
    {
        public int Id { get; private set; }
        public string Description { get; set; }

        public int DescriptionsLanguageId { get; set; }
    }
}
