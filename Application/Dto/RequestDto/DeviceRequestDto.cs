
namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class DeviceRequestDto
    {
        public int Id { get; private set; }
        public int ExternalId { get; set; }
        public int DeviceCode { get; set; }
        public string DeviceIp { get; set; }

        public int FactoryId { get; set; }


    }
}
