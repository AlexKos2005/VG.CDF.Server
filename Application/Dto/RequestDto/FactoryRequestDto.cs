
namespace VG.CDF.Server.Application.Dto.RequestDto
{
   public class FactoryRequestDto
    {
        public int Id { get; private set; }
        public int ExternalId { get; set; }

        public int UtcOffset { get; set; }

        public string Description { get; set; }

    }
}
