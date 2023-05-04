using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VG.CDF.Server.Application.Models.ExcelModels
{
    public class CollumnData
    {
        public int CollumnIdValue { get; set; }
        public string CollumnName { get; set; }= string.Empty;
        public List<string> Values { get; set; } = new List<string>();
    }
}
