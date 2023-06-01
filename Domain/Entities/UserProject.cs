
using System;
using System.ComponentModel.DataAnnotations;


namespace VG.CDF.Server.Domain.Entities
{
    public class UserProject
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
