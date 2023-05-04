using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VG.CDF.Server.Domain.Entities
{
    [Index(nameof(ExternalId), IsUnique = true)]
    public class Factory
    {
        public Factory()
        {
            UsersFactories = new List<UserFactory>();
            Devices = new List<Device>();
            Folders = new List<Folder>();
        }
        [Key]
        public int Id { get; set; }
        public int ExternalId { get; set; }

        public int UtcOffset { get; set; }

        public string Description { get; set; }
        public List<UserFactory> UsersFactories { get; set; }

        public List<Device> Devices { get; set; }

        public List<Folder> Folders { get; set; }
        public FactoryActionsInfo FactoryActionsInfo { get; set; }
        
        public TagReportTask TagReportTask { get; set; }
    }
}
