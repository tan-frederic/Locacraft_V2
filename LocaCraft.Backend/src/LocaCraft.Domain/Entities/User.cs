using LocaCraft.Domain.Bases;
using System.ComponentModel.DataAnnotations;

namespace LocaCraft.API.Entities
{
    public class User : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required, MaxLength(50), EmailAddress]
        public string Mail { get; set; } = null!;
    }
}
