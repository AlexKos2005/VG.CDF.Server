
using System.ComponentModel.DataAnnotations;


namespace VG.CDF.Server.Domain.Entities
{
    public class UserFactory
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int FactoryId { get; set; }
        public Factory Factory { get; set; }
    }
}
