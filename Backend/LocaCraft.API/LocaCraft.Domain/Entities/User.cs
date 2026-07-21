using System.ComponentModel.DataAnnotations;

namespace LocaCraft.API.Entities
{
    public class User
    {
        [Required, MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required, MaxLength(50), EmailAddress]
        public string Mail { get; set; } = null!;
    }
}
