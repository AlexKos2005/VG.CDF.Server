using BreadCommunityWeb.Blz.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
    public class TagParamRequestDto
    {
        public int Id { get; private set; }

        public int ExternalId { get; set; }

        public int ParameterGroupId { get; set; }

        public TagValueTypeCodes ValueType { get; set; }
    }
}
