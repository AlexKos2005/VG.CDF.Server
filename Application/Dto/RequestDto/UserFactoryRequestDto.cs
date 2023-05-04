using System;
using System.Collections.Generic;
using System.Text;

namespace VG.CDF.Server.Application.Dto.RequestDto
{
   public class UserFactoryRequestDto
    {
        public int UserId { get; set; }
        public UserRequestDto User { get; set; }

        public int FactoryId { get; set; }
        public FactoryRequestDto Factory { get; set; }
    }
}
