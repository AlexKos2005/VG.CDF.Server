using System.Collections.Generic;


namespace VG.CDF.Server.Application.Dto.RequestDto
{
    public class DeviceLanguageDescriptionRequestDto
    {
        public int Id { get; private set; }

        public string Description { get; set; }

        public ICollection<DeviceLanguageDescriptionRequestDto> DeviceLanguageDescriptions { get; set; }

    }
}
