using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VG.CDF.Server.Application.Dto.RequestDto;
using VG.CDF.Server.Application.Dto.ResponseDto;

namespace VG.CDF.Server.Application.Interfaces.Services
{
    public interface ITagsLiveService : ICrudService<TagLiveRequestDto, TagLiveResponseDto,long>
    {
        Task<int> GetTagsLiveCount();

        Task<List<TagLiveResponseDto>> GetAllTagsLive();
        Task<List<TagLiveResponseDto>> GetByTagsGroup(long tagsGroupId);

        Task<List<TagLiveResponseDto>> Get(int factoryExternalId,int  deviceExternalId,DateTime date);

        Task<List<TagLiveResponseDto>> Get(int factoryExternalId, int deviceExternalId, DateTime startDate, DateTime endDate);
        Task Save(List<TagLiveRequestDto> tagsLives);
    }
}
