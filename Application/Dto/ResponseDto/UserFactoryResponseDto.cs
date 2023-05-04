using System;
using System.Collections.Generic;
using System.Text;

namespace VG.CDF.Server.Application.Dto.ResponseDto
{
   public class UserFactoryResponseDto
    {
        public int UserId { get; set; }
        public UserResponseDto User { get; set; }

        public int FactoryId { get; set; }
        public FactoryResponseDto Factory { get; set; }
    }
}
