using LocaCraft.Domain.Bases;
using System.ComponentModel.DataAnnotations;

namespace LocaCraft.API.Entities
{
    public class RealEstate : BaseEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public int PostalCode { get; set; }
    }
}
