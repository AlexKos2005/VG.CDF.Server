using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Application.Dto.RequestDto
{
    public class ParameterGroupRequestDto
    {
        public int Id { get; private set; }

        public int ParameterGroupExternalId { get; set; }

        public string Name { get; set; }
    }
}
