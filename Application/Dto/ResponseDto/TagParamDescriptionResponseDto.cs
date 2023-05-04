
namespace VG.CDF.Server.Application.Dto.ResponseDto
{
    public class TagParamDescriptionResponseDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int TagParamId { get; set; }

        public int DescriptionsLanguageId { get; set; }

        public TagParamResponseDto TagParam { get; set; }

        public LanguageResponseDto DescriptionsLanguage { get; set; }

    }
}
